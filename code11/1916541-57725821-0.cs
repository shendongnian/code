    using NAudio.CoreAudioApi;
    using (var devices = new MMDeviceEnumerator())
    {
        foreach (var device in devices.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active))
        {
            // do something with device
        }
    }
