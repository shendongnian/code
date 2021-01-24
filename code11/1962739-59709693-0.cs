	[Export ("scene:willConnectToSession:options:")]
	public void WillConnect (UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
	{
		// Use this method to optionally configure and attach the UIWindow `window` to the provided UIWindowScene `scene`.
		// If using a storyboard, the `window` property will automatically be initialized and attached to the scene.
		// This delegate does not imply the connecting scene or session are new (see UIApplicationDelegate `GetConfiguration` instead).
		UIWindowScene myScene = scene as UIWindowScene;
		Window = new UIWindow(myScene);
		UIViewController controller = new UIViewController();
		controller.View.BackgroundColor = UIColor.LightGray;
		controller.Title = "My Controller";
		UINavigationController navigationMain = new UINavigationController(controller);
		Window.RootViewController = navigationMain;
		Window.MakeKeyAndVisible();
	}
