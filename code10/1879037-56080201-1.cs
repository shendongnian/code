    private string _email;
    public string Email
    {
        get
        {
            if (String.IsNullOrEmpty(_email))
                return "";
            else
                return Crypto.Decrypt(_email, GlobalVars.VALID_KEY);
        }
        set
        {
            _email = value;
        }
    }
