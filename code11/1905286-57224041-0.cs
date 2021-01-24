    var window= UIApplication.SharedApplication.KeyWindow;
    var vc = window.RootViewController;
    while (vc.PresentedViewController != null)
    {
        vc = vc.PresentedViewController;
    }
    
    //Create Alert
    var okAlertController = UIAlertController.Create("Error", "Error registering push notifications", UIAlertControllerStyle.Alert);
    
    //Add Action
    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
    
    // Present Alert
    vc.PresentViewController(okAlertController, true, null);
