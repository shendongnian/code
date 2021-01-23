    string language = "";
    System.Windows.Input.InputLanguageManager.Current.InputLanguageChanged += 
           new    InputLanguageEventHandler((sender, e) =>
    {
       language = e.NewLanguage.DisplayName;
    }); 
