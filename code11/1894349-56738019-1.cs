    public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    {
        // switch
        UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0,0,0);
        return base.FinishedLaunching (app, options);
    }
