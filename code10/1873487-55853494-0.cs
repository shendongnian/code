    '[assembly: ExportRenderer(typeof(CardPage), typeof(MyiOSTabbedPage))]
     [assembly: ExportRenderer(typeof(LoginPage), typeof(MyiOSTabbedPage))]
     [assembly: ExportRenderer(typeof(MemberAboutPage), typeof(MyiOSTabbedPage))]
     [assembly: ExportRenderer(typeof(MapPage), typeof(MyiOSTabbedPage))]
     namespace CHA.iOS.Renderers
     {
     public class MyiOSTabbedPage : PageRenderer
    {
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            nfloat tabSize = 44.0f;
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
            CGRect rect = this.View.Frame;
            rect.Y = this.NavigationController != null ? tabSize : tabSize + 20;
            this.View.Frame = rect;
            if (TabBarController != null)
            {
                CGRect tabFrame = this.TabBarController.TabBar.Frame;
                tabFrame.Height = tabSize;
                tabFrame.Y = this.NavigationController != null ? 0 : 0;
                this.TabBarController.TabBar.Frame = tabFrame;
                this.TabBarController.TabBar.BarTintColor = UIColor.FromRGB(234,232,232);
                var textAttr = new UITextAttributes
                {
                    Font = UIFont.SystemFontOfSize(20)
                };
                var selectedAttr = new UITextAttributes
                {
                    TextColor = UIColor.FromRGB(63,165,186),
                    Font=UIFont.BoldSystemFontOfSize(20)
                };
                foreach (var i in this.TabBarController.TabBar.Items)
                {
                    i.SetTitleTextAttributes(textAttr, UIControlState.Normal);
                    i.SetTitleTextAttributes(selectedAttr, UIControlState.Selected);
                }
            }
        }
    }'
