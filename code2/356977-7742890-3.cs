    public virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(sender, e);
    }
