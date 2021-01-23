    var devices = await devconHelper.GetDevicesAsync();
    var device = devices.FirstOrDefault(x => x.Name == Settings.GPSDeviceName);
    if (device != null)
    {
        logger.Trace("Found the device!");
        logger.Info("Disabling the device!");
        if (await devconHelper.DisableAsync(device))
        {
            logger.Info("GPS device has been disabled!");
        }
        else
        {
            logger.Warn("Failed to disable the device!");
        }
        await Task.Delay(1000);
        logger.Info("Enabling device!");
        if (await devconHelper.EnableAsync(device))
        {
            logger.Info("Device has been enabled!");
        }
        else
        {
            logger.Fatal("Failed to enable the device!");
        }
    }
    else
    {
        logger.Warn("Could not find the device!");
    }
