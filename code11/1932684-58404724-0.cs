    private async void CloseCurrentlyConnectedDevice()
    {
        if (device != null)
        {
            // Notify callback that we're about to close the device
            if (deviceCloseCallback != null)
            {
                deviceCloseCallback(this, deviceInformation);
            }
            // This closes the handle to the device
            device.Dispose();
            device = null;
        }
    }
