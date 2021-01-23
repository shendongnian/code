    private string _text;
    public string Text
    {
        get { return _text; }
        set
        {
            if (value != null)
                _text = value;
            else
                _text = string.Empty;
        }
    }
