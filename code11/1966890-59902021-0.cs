    public DateTime? StatusDateFormatted { get; private set; }
    
    // Backing field for your persisted property
    private string statusDate;
    public string StatusDate 
    {
        get { return statusDate; }
        set {
            // Each time the value is set, attempt to parse it and cache the value
            DateTime parsedDate;
            bool parsed = DateTime.TryParseExact(
                date, 
                "yyyyMMdd", 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, 
                out parsedDate);
            // Clear the value in case the date cannot be parsed
            StatusDateFormatted = null;
            if (parsed)
            {
                // Cache the parsed value
                StatusDateFormatted = parsedDate;
            }        
        }
    }
