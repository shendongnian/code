    private string _typedText;
    public string TypedText
    {
        get { return _typedText; }
        set
        {
            _typedText = value.ToUpper();
            NotifyPropertyChanged("TypedText");
        }
    }
