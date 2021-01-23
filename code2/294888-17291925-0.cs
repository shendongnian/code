    public static dynamic GetTheListOfDevicesDependOnDB(int projectID)
    {
        List<Devices_Settings> ListDevices_Settings = new List<Devices_Settings>();
        var db = new First_DataContext();
        var devices = (dynamic) null;
        switch (projectID)
        {
            case (int)enmProjectType.First:
                db = new First_DataContext();
                devices = db.Device_Fisrt.ToList();   
                break;
            case (int)enmProjectType.Second:
                 var db1 = new Second_DataContext();
                 devices = db1.Device_Second.ToList();
                break;
 
            default:
                break;
        }
        foreach (var item in devices)
        {
           //TODO
        }
        return ListDevices_Settings;
}
