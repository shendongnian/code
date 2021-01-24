     public void GotoDetailsPage() =>
         NavigationService.Navigate(typeof(Views.DetailPage), Value);
    
     public void GotoSettings() =>
         NavigationService.Navigate(typeof(Views.SettingsPage), 0);
