    private void btnChangeLanguage_Click(object sender, RoutedEventArgs e)
    {
        if (LocalizationHelper.IsCultureItalian(App.LocalizationHelper.GetCurrentLocalizationCode()))
            App.LocalizationHelper.ChangeLocalizationTo("en-US");
        else App.LocalizationHelper.ChangeLocalizationTo("it-IT");
        //refresh current page
        Frame.Navigate(this.GetType());
    }
