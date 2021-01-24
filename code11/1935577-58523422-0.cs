    private DateTime _actualDateTime;
    public string DateTimeForDisplay
    {
        get 
        {
            return _actualDateTime.ToString("d") +" "+ _actualDateTime.ToString("HH:mm:ss");
        }
    }
