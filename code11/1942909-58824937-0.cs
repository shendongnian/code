      MainPage = GetMainPage();
      MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Green);
      public static Page GetMainPage()
        {
            return new HomePage();  //home page is a tabbed page
         }
