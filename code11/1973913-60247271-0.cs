      public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions){
         this.Window = new UIWindow(UIScreen.MainScreen.Bounds);
         UINavigationController navigationController = new 
         UINavigationController(new SplashViewController());
         Window.RootViewController = navigationController;
}
