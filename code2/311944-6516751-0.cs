    private Dictionary<INotifyPropertyChanged, List<string>> sourceMap =
        new Dictionary<INotifyPropertyChanged, List<string>>();
    private void ListenToPropertyChangedEvent(INotifyPropertyChanged source,
                                                string propertyName)
    {
        if (sourceMap.ContainsKey(source))
            sourceMap[source].Add(propertyName);
        else
        {
            source.PropertyChanged += source_PropertyChanged;
            sourceMap[source] = new List<string> { propertyName };
        }
    }
    void source_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var source = sender as INotifyPropertyChanged;
        var list = sourceMap[source];
        if (list.Contains(e.PropertyName))
            MyMagicMethod();
    }
