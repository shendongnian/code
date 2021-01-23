    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
      var settings = LoadMySettingsFromIS();
      if (settings =! null)
      {
        // update it here
      }
      base.OnNavigatedTo(e);
    }
