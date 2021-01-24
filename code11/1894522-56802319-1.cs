    public static void ChangeTheme(AppTheme theme)
    {
      try
      {
        if (theme == m_currentTheme)
        {     
          return;
        }
        // A brand new dictionary object is created here. 
        // It's not assigned to anything yet.
        // If you want to swith RD in your global App resources, 
        // creating a new dictionary is not necessary at all, 
        // you may just use Application.Current.Resources.MergedDictionaries instead
        ResourceDictionary appStyles = new ResourceDictionary();
        // you load the contents of the xml file. Still not assigned to anything
        appStyles.Source = new Uri("/MyApp.UserInterface.WPF;component/AppStyles.xaml", UriKind.RelativeOrAbsolute);
        // the theme loaded from the xml is removed from the dictionary
        appStyles.MergedDictionaries.Clear();
        ResourceDictionary newTheme = new ResourceDictionary();
        newTheme.Source = new Uri(string.Format("/MyApp.UserInterface.WPF;component/Themes/{0}Theme.xaml", theme.ToString()), UriKind.RelativeOrAbsolute);
 
        // new theme is added to the dictionary. 
        // The dictionary itself is still not assigned to anything...
        appStyles.MergedDictionaries.Add(newTheme);        
        m_currentTheme = theme;
      }
      catch (Exception ex)
      {
        TraceError(ex.ToString());        
      }
    }
