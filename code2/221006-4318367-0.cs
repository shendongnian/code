    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set 
        {
            var v = value ?? string.Empty; 
            _phoneNumber = v.Length <= 30 ? v : "EXCEEDS LENGTH"; 
        }
    }
    private string _phoneNumber;
