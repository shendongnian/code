    private string _firstName;
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            if (value != "Bob")
              throw new ArgumentException("Only Bobs are allowed here!");
            _firstName = value;
        }
    }
