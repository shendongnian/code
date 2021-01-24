    private List<string> _ImageTypes;
    public List<string> ImageTypes
    {
        get { return _ImageTypes; }
        set
        {
            _ImageTypes = CreateListFrom(value);
        }
    }
