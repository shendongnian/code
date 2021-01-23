    private void OnFailed(uint errorCode, string message)
    {
        ThreadPoolTimer.CreateTimer((timer) => {
        UI.ErrorMessage = string.Format("Error: 0x{0:X} {1}", errorCode, message);
        }, System.TimeSpan.FromMilliseconds(100));
    }
