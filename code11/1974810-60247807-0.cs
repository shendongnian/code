            UIAlertController vc = UIAlertController.Create("", titleWeSendFromMessageCenterArgs, UIAlertControllerStyle.Alert);
            UIAlertAction action = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
            vc.AddAction(action);
            vc.View.TintColor = UIColor.Red;//or whatever you want
            Window.RootViewController.PresentViewController(vc, true, null);
