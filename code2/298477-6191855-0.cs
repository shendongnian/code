    public string DoSomething(object value)
    {
        var year = value.ToString();  // or alterinately...
        var year = value as string();
        if (!string.IsNullOrEmpty(year))
        {
            // do something to the year
            return year;
        }
        return ""; // default in case you can't process the value
    }
