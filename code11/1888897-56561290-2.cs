    public CTCallCenter c { get; set; }
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        global::Xamarin.Forms.Forms.Init();
        LoadApplication(new App());
        c = new CTCallCenter();
        c.CallEventHandler = delegate (CTCall call)
        {
            if (call.CallState == call.StateIncoming)
            {                                
            }
            else if (call.CallState == call.StateDialing)
            {
            }
            else if (call.CallState == call.StateConnected)
            {
                try
                {
                    MessagingCenter.Send<Object>(new Object(), "CallConnected");
                }
                catch (Exception ex)
                {
                }
            }
            else if (call.CallState == call.StateDisconnected)
            {
             try {                     
                    MessagingCenter.Send<Object>(new Object(), "CallEnded");
                
                 }
                 catch( Exception ex)
                 {
                 }
            }
        };
        return base.FinishedLaunching(app, options);
    }
