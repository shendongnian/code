    var manager = new DeviceManagerClass();
    Item wiaItem;
    Device device = null;
    foreach (var info in manager.DeviceInfos)
    {
        if (info.DeviceID == DESIRED_DEVICE_ID)
        {
            device = info.Connect();
            wiaItem = device.ExecuteCommand(CommandID.wiaCommandTakePicture);
        }
    }
