    System.Collections.IEnumerator enumerator = Properties.Settings.Default.Properties.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        Debug.WriteLine(((System.Configuration.SettingsProperty)enumerator.Current).Name);
    }
