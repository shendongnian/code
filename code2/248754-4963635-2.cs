    private void SomeMethod()
    {
        CreateXamlWithBindingValues("UserControl1.xaml", "UserControl1_Saved.xaml");
    }
    private void CreateXamlWithBindingValues(string sourcePath, string savePath)
    {
        StreamReader streamReader = new StreamReader(sourcePath);
        StringReader stringReader = new StringReader(streamReader.ReadToEnd());
        XmlReader xmlReader = XmlReader.Create(stringReader);
        FrameworkElement loadedObject = (FrameworkElement)XamlReader.Load(xmlReader);
        loadedObject.DataContext = UserControlViewModel;
        RoutedEventHandler routedEventHandler = null;
        routedEventHandler = new RoutedEventHandler(delegate
        {
            loadedObject.Loaded -= routedEventHandler;
            grid1.Children.Remove(loadedObject);
            string savedObject = XamlWriter.Save(loadedObject);
            StreamWriter streamWriter = new StreamWriter(savePath);
            streamWriter.Write(savedObject);
            streamWriter.Close();
        });
        loadedObject.Loaded += routedEventHandler;
        grid1.Children.Add(loadedObject);
    }
