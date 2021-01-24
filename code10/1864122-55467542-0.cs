    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        global::Xamarin.Forms.Forms.Init();
        TopTabbedRenderer.Init(); //add this line
        LoadApplication(new App());
        return base.FinishedLaunching(app, options);
    }
