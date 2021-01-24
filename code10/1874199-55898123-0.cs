    public bool Value
    {
        get
        {
            return Properties.Settings.Default.YesOrNoControlValue;
        }
        set
        {
            Properties.Settings.Default["YesOrNoControlValue"] = value;
            Properties.Settings.Default.Save();
        }
    }
