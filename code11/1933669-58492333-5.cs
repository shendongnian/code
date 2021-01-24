    [assembly: Dependency(typeof(StatusBarStyleManager))]
    namespace ShaXam.iOS.DependencyServices
    {
        public class StatusBarStyleManager : IStatusBarStyleManager
        {
            public void SetColoredStatusBar(string hexColor)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                    if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                    {
                        statusBar.BackgroundColor = Color.FromHex(hexColor).ToUIColor();
                    }
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
                    GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                });
            }
    
            public void SetWhiteStatusBar()
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                    if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                    {
                        statusBar.BackgroundColor = UIColor.White;
                    }
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, false);
                    GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                });
            }
    
            UIViewController GetCurrentViewController()
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                    vc = vc.PresentedViewController;
                return vc;
            }
        }
    }
