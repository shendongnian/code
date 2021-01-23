    public string ExpirationDate
    {
        get 
        {
            return new DateTime(Year, Month, 1).ToString("MM/yyyy");
        }
    }
