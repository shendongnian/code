    public override void ViewDidAppear(bool animated)
    {
        base.ViewDidAppear(animated);
        if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        {
            //Obj-C: 
            // UIView *statusBar = [[UIView alloc]initWithFrame:[UIApplication sharedApplication].keyWindow.windowScene.statusBarManager.statusBarFrame] ;
            // statusBar.backgroundColor = [UIColor redColor];
            // [[UIApplication sharedApplication].keyWindow addSubview:statusBar];
    
            // Xamarin.iOS: 
            UIView statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame);
            statusBar.BackgroundColor = UIColor.Red;
            UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
        }
        else
        {
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = UIColor.Red;
                statusBar.TintColor = UIColor.White;
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
            }
        }
    }
