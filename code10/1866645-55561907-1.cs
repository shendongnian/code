    void PreventPinning(IntPtr handle)
    {
        var appID = "MyAppNoPin";
        var propGuid = new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}");
        var ID = new PropertyKey(propGuid, 5);              // System.AppUserModel.ID
        var PreventPinning = new PropertyKey(propGuid, 9);  // System.AppUserModel.PreventPinning
        //Important: Set PreventPinning before ID
        WindowProperties.SetWindowProperty(handle, PreventPinning, "True");
        WindowProperties.SetWindowProperty(handle, ID, appID);
    }
