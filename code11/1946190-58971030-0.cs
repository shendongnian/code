        UIViewControllerD controlD =new UIViewControllerD();
        Action action = () => {
            NavigationController.PopToRootViewController(true);
        };
        myButton.TouchUpInside += (sender, e) => {
            
            //1. navigate to D
            //NavigationController.PushViewController(new UIViewControllerD(), true);
            
            //2. present D
            NavigationController.PresentViewController(controlD, true, action);
        };
