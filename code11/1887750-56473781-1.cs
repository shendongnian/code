    public App()
    {
        InitializeComponent();
    
        MainPage = new NavigationPage(new MainPage());
    
        MessagingCenter.Subscribe<object, object>(this, "Navigate", (sender, args) =>
        {
            if ((string)args == "a")
            {
                MainPage = new SecondPage();
    
                // or (MainPage as NavigationPage).PushAsync(new SecondPage());
            }
        });
    }
