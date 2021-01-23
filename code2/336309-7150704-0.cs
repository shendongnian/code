    using (FileStream fs = new FileStream("MainResources.xaml", FileMode.Open))
    {
        ResourceDictionary dic = (ResourceDictionary) XamlReader.Load(fs);
        Resources.MergedDictionaries.Clear();
        Resources.MergedDictionaries.Add(dic);
    }
