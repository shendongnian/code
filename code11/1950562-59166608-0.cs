    public string MyItem
    {
        get => _myItem;
        set
        {
            SetValue(ref _myItem, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsMilkItem"));
           
        }
    }
