    private string firstName;
    public String FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            // validate the input
            if (string.IsNullOrEmpty(value))
            {
                // throw exception, or do whatever
            }
            firstName = value;
        }
    }
