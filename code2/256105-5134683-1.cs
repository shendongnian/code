    private string _txt
    public string text
    {
        get
        {
            return _txt;
        }
        set
        {
            _txt = string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }
