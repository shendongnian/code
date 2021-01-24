    private string _filename;
    public string FileName
    {
        get { return _filename; }
        set
        {
            string oldValue = _filename;
            string newValue = value;
            //update...
            _filename = value;
        }
    }
