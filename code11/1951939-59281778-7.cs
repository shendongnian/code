     using Foundation;
     using UIKit;
     using Xamarin.Forms.Platform.iOS;
     using Xamarin.Forms;
     using xxx.iOS;
     using CoreGraphics;
     using xxx;
     using ObjCRuntime;
     [assembly: ExportRenderer(typeof(BaseContentPage), typeof(MyPageRenderer))]
     namespace xxx.iOS
     {
    public class MyPageRenderer: PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            var page = Element as Page1;
            NavigationController.NavigationBar.Hidden = true;
            double height = IsiphoneX();
            UIView backView = new UIView()
            {
                BackgroundColor = UIColor.White,
                Frame = new CGRect(0,20,UIScreen.MainScreen.Bounds.Width, height),
            };
            UIButton backBtn = new UIButton() {
                Frame = new CGRect(20, height-44, 40, 44),
                Font = UIFont.SystemFontOfSize(18),
            } ;
            backBtn.SetTitle("Back", UIControlState.Normal);
            backBtn.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            backBtn.AddTarget(this,new Selector("GoBack"),UIControlEvent.TouchUpInside);
            UILabel titleLabel = new UILabel() {
                Frame=new CGRect(UIScreen.MainScreen.Bounds.Width/2-75, 0,150, height),
                Font = UIFont.SystemFontOfSize(20),
                Text = page.Title,
                TextColor = UIColor.Black,
                Lines = 0,
            };
            UILabel line = new UILabel() {
                Frame = new CGRect(0, height, UIScreen.MainScreen.Bounds.Width, 0.5),
                BackgroundColor = UIColor.Black,
            };
            backView.AddSubview(backBtn);
            backView.AddSubview(titleLabel);
            backView.AddSubview(line);
            View.AddSubview(backView);
        }
         double IsiphoneX()
        {
            double height = 44;
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                if (UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom > 0.0)
                {
                    height = 64;
                }
            }
            return height;
        }
        [Export("GoBack")]
        void GoBack()
        {
            NavigationController.PopViewController(true);
        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NavigationController.NavigationBar.Hidden = false;
        }
      }
     }
