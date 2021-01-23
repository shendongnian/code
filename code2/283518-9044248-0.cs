    bool CameraTest()
    {
    bool present = false;
    
    try
    {
        Device d = class1.ShowSelectDevice(WiaDeviceType.CameraDeviceType, true, false);
        present = true;
    }
    catch (Exception ex)
    {}
    
    return present;
    }
