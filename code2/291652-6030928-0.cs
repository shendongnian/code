        Uri uri = new Uri("Resources/MyDict.xaml", UriKind.Relative);
        StreamResourceInfo info = Application.GetContentStream(uri);
        System.Windows.Markup.XamlReader reader = new System.Windows.Markup.XamlReader();
        ResourceDictionary myResourceDictionary = 
                                       (ResourceDictionary)reader.LoadAsync(info.Stream);
        Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
