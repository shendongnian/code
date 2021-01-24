public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	Xamarin.IQKeyboardManager.SharedManager.EnableAutoToolbar = true;
	Xamarin.IQKeyboardManager.SharedManager.ShouldResignOnTouchOutside = true;
    Xamarin.IQKeyboardManager.SharedManager.ShouldToolbarUsesTextFieldTintColor = true;
    Xamarin.IQKeyboardManager.SharedManager.KeyboardDistanceFromTextField = 300f;
    //...
}
For more details you could check https://github.com/TheEightBot/Xamarin.IQKeyboardManager
