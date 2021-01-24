    public enum DBcon
    {
          DB1, DB2
    }
    public static Suburb FromCsv(string csvLine, DBcon con)
    {
        var context = con == DBcon.DB1 ? new CATALOGContext() : new DB2Context();
    
        if (csvLine == null) throw new ArgumentNullException(nameof(csvLine));
        if (context == null) throw new ArgumentNullException(nameof(context));
        var values = csvLine.Split(',');
        if (context.States == null) return null;
        if (values.Length <= 3) return null;
        var suburb = new Suburb
        {
            PostCode = values[0],
            SuburbName = values[1],
            State = context.States.FirstOrDefault(s => s.StateShortName == values[2]),
            Latitude = Convert.ToDouble(values[3], CultureInfo.CurrentCulture),
            Longitude = Convert.ToDouble(values[4], CultureInfo.CurrentCulture)
        };
        return suburb;
    }
