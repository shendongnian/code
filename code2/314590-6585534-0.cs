    public TaskbarIcon MyTaskbarIcon { get; set; }
    
    protected override void OnStartup(StartupEventArgs e)
    {
    	base.OnStartup(e);
    	Popup pu = new Popup();
    	pu.Child = MyTaskbarIcon;
    	//...
    }
