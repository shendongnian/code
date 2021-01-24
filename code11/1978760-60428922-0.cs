    public string InstanceId = "";
    public App()
    {
        InstanceId = Guid.NewGuid().ToString();
    }
    protected override void OnStart()
    {
        Settings.ActiveInstanceId = InstanceId;
    }
 
    protected override void OnSleep()
    {
        if(Settings.ActiveInstanceId == InstanceId)
        {
            Settings.ActiveInstanceId = "";
        }
    }
