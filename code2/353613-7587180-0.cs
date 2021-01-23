    public string Name
    {
        get { return name; }
        set
        {
            if(String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name must have a value");
            if(value.Length > 35)
                throw new ArgumentException("Name cannot be longer than 35 characters");
            if(value.Any(c => char.IsDigit(c))
                throw new ArgumentException("Name cannot contain numbers");
            name = value;
        }
    }
