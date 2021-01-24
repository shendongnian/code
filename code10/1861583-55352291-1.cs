    public static String Uploadstring
    {
        get
        {
            return _uploadstring;
        }
        set
        {
            _uploadstring = value;
            Form.ttts.Text = _uploadstring;  // This line (Modified)
        }
    }
