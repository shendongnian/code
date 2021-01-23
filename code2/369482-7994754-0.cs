    public const DateTime NULL_DATE_CONST = DateTime.Parse("01/01/2000 00:00");
    
    [WebMethod]
    public DateTime NullDate()
    {
        return NULL_DATE_CONST;
    }
