        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NSNotificationCenter.DefaultCenter.AddObserver(new NSString("timeoutNotification"), handleInactivityNotification);
        }
        public void handleInactivityNotification(NSNotification notification)
        {
            //Return to login page (Root view controller)
            this.NavigationController.PopToRootViewController(true);
        }
