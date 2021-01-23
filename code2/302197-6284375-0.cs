    var myResourceDictionary = new ResourceDictionary();
    var uriPath = string.Format("/{0};component/resource/Resources.xaml", 
        typeof(classInAssembly).Assembly.Name);
    var uri = new Uri(uriPath, UriKind.RelativeOrAbsolute);
    myResourceDictionary.Source = uri;
    Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
