	[Export("application:openURL:sourceApplication:annotation:")]
	public bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
	{
		if (sourceApplication == "com.apple.SafariViewService")
		{
			var dict = HttpUtility.ParseQueryString(url.Query);
			var token = dict["access_token"];
			NSNotificationCenter.DefaultCenter.PostNotificationName("kCloseSafariViewControllerNotification", new NSString(token));
		};
		return true;
	}
