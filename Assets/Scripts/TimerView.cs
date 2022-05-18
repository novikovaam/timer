using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText = default;
    [SerializeField] private Button _runButton = default;
    [SerializeField] private Button _stopButton = default;

    private float _currentTime = 0f;
    private bool _isActive = false;

    private void Awake()
    {
        UpdateTimeText();
    }

    private void OnEnable()
    {
        _runButton.onClick.AddListener(OnRunButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
    }

    private void OnRunButtonClick()
    {
        _isActive = true;
    }

    private void OnStopButtonClick()
    {
        _isActive = false;
    }


    private void Update()
    {
        if (_isActive)
        {
            _currentTime += Time.deltaTime;
            UpdateTimeText();
        }
    }

    private void UpdateTimeText()
    {
        int hours = (int)(_currentTime / 3600);
        int minutes = (int)(_currentTime / 60);
        int seconds = (int)(_currentTime % 60);

        _timeText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}