    public void SetLanguageDictionary(string lang)
    {
      ResourceDictionary dict = new ResourceDictionary();
      //switch (Thread.CurrentThread.CurrentCulture.ToString())
      switch (lang)
       {
           case "english":
             dict.Source = new Uri("Lang\\win_en_US.xaml", UriKind.Relative);
             break;
           case "hindi":
             dict.Source = new Uri("Lang\\win_hi_IN.xaml", UriKind.Relative);
             break;
            }
         //this.Resources.MergedDictionaries.Add(dict);
         Application.Current.Resources.MergedDictionaries.Add(dict);
     } 
