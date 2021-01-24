    public DateTime Convert_date(string date)
    {
        DateTime dt = new DateTime();
    
        string format ="M/d/yyyy h:mm:ss tt";
    
        if(DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, 
        DateTimeStyles.None, 
        out dt))
        {
            return dt;
        }
    
        MessageBox.Show("The string couldn't be converted to date time!");
        return dt;
    }
