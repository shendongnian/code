    #region INotifyPropertyChanged Members
    
    public event PropertyChangedEventHandler PropertyChanged;
    //TODO: Inherit interface System.ComponentModel.INotifyPropertyChanged.
    //TODO: Create properties with the propn code snippet.
    
    private void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null) {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    #endregion
