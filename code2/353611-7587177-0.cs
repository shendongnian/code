    public string Name
    {
        get { return name; }
        set 
        {
            if (value == "" || value.Length > 35)
            {
                throw new ArgumentException("Invalid name length.");
            }
            foreach (char item in value)
            {                        
                if (char.IsDigit(item))
                {
                    throw new ArgumentException("Digits are not allowed.");
                }
            }
            name = value;                
        }
    }
