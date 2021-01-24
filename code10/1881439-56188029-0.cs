        ...
        public static UIViewController VisibleViewController(this UIViewController controller)
        {
            if (controller == null)
                return null;
            if (controller is UINavigationController navController)
            {
                return navController.VisibleViewController();
            }
            else if (controller is UITabBarController tabController)
            {
                tabController.SelectedViewController?.VisibleViewController();
            }
            else
            {
                var vc =  controller.PresentedViewController?.VisibleViewController();
                if (vc != null)
                    return vc;
            }
            return controller;
        }
