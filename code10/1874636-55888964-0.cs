    private bool _isWorking = false;
    public async void SendLightData()
    {
        if (!_isWorking)
        {
            try
            {
               _isWorking = true;
               await ArduinoHandler.Current.WriteAsync(ArduinoHandler.DataEnum.LightArduino,
        ArduinoHandler.DataEnum.Light, Convert.ToByte(LightConstants.LightCommand.LightCommand),
        Convert.ToByte(Red), Convert.ToByte(Green), Convert.ToByte(Blue), Convert.ToByte(Alpha),
        WriteCancellationTokenSource.Token);
            }
            finally
            {
               _isWorking = false;
            }
    }
