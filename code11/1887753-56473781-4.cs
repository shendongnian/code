    public void MoveToPage(string pageName)
    {
        if (pageName == "a")
        {
            MainPage = new SecondPage();
            // or (MainPage as NavigationPage).PushAsync(new SecondPage());
        }
    }
