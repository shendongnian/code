    public static String Uploadstring
    {
        get
        {
            return _uploadstring;
        }
        set
        {
            _uploadstring = value;
            ttts.Text = _uploadstring;  // This line
        }
    }
