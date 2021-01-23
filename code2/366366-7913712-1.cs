    private void NotifyPropertyChanged(String propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler (this, new PropertyChangedEventArgs(propertyName));
        }
    }
