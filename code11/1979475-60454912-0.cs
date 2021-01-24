    protected override void OnAppearing()
    {
        base.OnAppearing();
        (MyContentView as MyContentView)?.PageAppearing();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        (MyContentView as MyContentView)?.PageDisappearing();
    }
