    <Border Width="{Binding Size}">
    private int _Size;
    public int Size
    {
        get { return _Size; }
        set 
        {
            _Size = value; 
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Size");
        }
    }
