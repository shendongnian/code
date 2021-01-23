    private System.Windows.Media.Brush _myBrush
    public System.Windows.Media.Brush MyBrush {
        get { return _myBrush; }
        set {
            if(value != _myBrush) {
                _myBrush = value;
                OnPropertyChanged("MyBrush");
            }
        }
    }
    protected virtual void OnPropertyChanged(string propertyName) {
        // ....
    }
