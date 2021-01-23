    public SetupWizard()
    {
        InitializeComponent();
        this.SettingManager.PropertyName = new RelayObject(CanEditSetting, 
                                                           CanDeleteSetting);
        // or (all can be deleted)
        this.SettingManager.PropertyName = new RelayObject(CanEditSetting, null);
        // or (all can be edited)
        this.SettingManager.PropertyName = new RelayObject(null, CanDeleteSetting);
        // or (all can be edited and deleted)
        this.SettingManager.PropertyName = new RelayObject();
    }
