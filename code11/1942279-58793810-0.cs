    private string _dsc = "";
    public string Description
    {
        get
        {
            int txtLen = _dsc.Length;
            int maxLen = 600;
            if (txtLen > 0)
            {
                string ellipsis = txtLen > maxLen ? "..." : "";
                return _dsc.Substring(0, txtLen > maxLen ? maxLen : txtLen) + ellipsis;
            }
            else
            {
                return "";
            }
        }
        set
        {
            _dsc = value;
        }
    }
