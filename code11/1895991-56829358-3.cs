public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
{
   //... 
   
   IQKeyboardManager.SharedManager.Enable = true;
 
   return true;
}
**Update:**
I create a demo without using stroryboard ,and you can refer it .
in AppDelegate
public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
{
   // create a new window instance based on the screen size
   Window = new UIWindow(UIScreen.MainScreen.Bounds);
   Window.RootViewController = new UINavigationController(new MainViewController());
   IQKeyboardManager.SharedManager.Enable = true;
   // make the window visible
   Window.MakeKeyAndVisible();
   return true;
}
>in MainViewController
public override void ViewDidLoad()
{
  View = new UniversalView();
  base.ViewDidLoad();
  Title = "Title";
  IQTextView textView = new IQTextView() {
      Frame = new CGRect(20, 90, UIScreen.MainScreen.Bounds.Width - 40, 626),
      BackgroundColor = UIColor.Red,
      Text = "xxx",
      Font = UIFont.SystemFontOfSize(14),
  };
  View.AddSubview(textView);
  // Perform any additional setup after loading the view
}
Your issue maybe because of you use auto layout . And you can use [Masonry][2] from Nuget .
  [1]: https://github.com/TheEightBot/Xamarin.IQKeyboardManager
  [2]: https://github.com/xamarin/XamarinComponents/tree/master/iOS/Masonry
