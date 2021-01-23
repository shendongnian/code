    public string getCommandText(ReportDocument rd)
    {
        if (!rd.IsLoaded)
            throw new ArgumentException("Please ensure that the reportDocument has been loaded before being passed to getCommandText");
        PropertyInfo pi = rd.Database.Tables.GetType().GetProperty("RasTables", BindingFlags.NonPublic | BindingFlags.Instance);
        return ((dynamic)pi.GetValue(rd.Database.Tables, pi.GetIndexParameters()))[0].CommandText;
    }
