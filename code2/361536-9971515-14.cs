    private string _selected;
    public string Selected
    {
        get { return _selected; }
        set
        {
            if (IsValidForSelection(value))
            {
                _selected = value;
            }
        }
    }
