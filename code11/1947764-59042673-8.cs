    private bool _IsOperationOnGoing;
    
    public bool IsOperationOnGoing
    {
        get { return _IsOperationOnGoing; }
        set {
            if (_IsOperationOnGoing != value)
            {
                _IsOperationOnGoing = value;
    
                SafeOperationToGuiThread(() => Mouse.OverrideCursor = (_IsOperationOnGoing) ? Cursors.Wait : null  );
                OnPropertyChanged(nameof(IsOperationOnGoing));
            }
        }
    }
