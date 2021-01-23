	public static class MyExtensions
	{
		public static void SetCustomBackButton(this UIViewController uiViewController, string buttonText, Action onClick)
		{
			uiViewController.NavigationItem.HidesBackButton = true;
			var dummyButton = UIButton.FromType (UIButtonType.Custom);
			var backButton = (UIButton)MonoTouch.ObjCRuntime.Runtime.GetNSObject (
				MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_int (
				dummyButton.ClassHandle, MonoTouch.ObjCRuntime.Selector.GetHandle ("buttonWithType:"), 101));
			
			backButton.SetTitle (buttonText, UIControlState.Normal);
			
			backButton.TouchUpInside += delegate {
				if (onClick != null)
					onClick ();
				else
					uiViewController.NavigationController.PopViewControllerAnimated (true);
			};
			
			uiViewController.NavigationItem.LeftBarButtonItem = new UIBarButtonItem (backButton);
		}
	}
