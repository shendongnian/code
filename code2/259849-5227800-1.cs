    Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
    void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Settings.Default.Save();
    }
