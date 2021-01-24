    public override void ViewWillAppear(bool animated)
    {
        base.ViewWillAppear(animated);
        Xamarin.IQKeyboardManager.SharedManager.Enable = false;
    }
    public override void ViewWillDisappear(bool animated)
    {
        base.ViewWillDisappear(animated);
        Xamarin.IQKeyboardManager.SharedManager.Enable = true;
    }
