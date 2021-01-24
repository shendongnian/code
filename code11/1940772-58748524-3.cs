     public MainPage()
     {
         InitializeComponent();
         this.DataContext = new LocalizedStrings();
     }
    
     private async void btnChangeLanguage_Click(object sender, RoutedEventArgs e)
     {
         if (LocalizationHelper.IsCultureItalian(App.LocalizationHelper.GetCurrentLocalizationCode()))
             App.LocalizationHelper.ChangeLocalizationTo("en-US");
         else App.LocalizationHelper.ChangeLocalizationTo("it-IT");
         await Task.Delay(100); // used to prepare the resource.
         this.DataContext = new LocalizedStrings();
     }
