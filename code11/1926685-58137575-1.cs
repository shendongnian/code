    private bool _isButtonVisible = true;
    public bool IsButtonVisible
    {
        get { return _isButtonVisible; }
        set
        {
            if (value == _isButtonVisible) return;
            _isButtonVisible = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    //[NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
