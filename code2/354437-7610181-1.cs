    private void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
