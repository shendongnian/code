    if ( Properties.Settings.Default.IsFirstLaunch )
    {
      Properties.Settings.Default.IsFirstLaunch = false;
      Properties.Settings.Default.Save();
      MessageBox.Show("Welcome");
    }
