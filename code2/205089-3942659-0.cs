    public DateTime ShippedDate;
    [FieldConverter(ConverterKind.Date, "ddMMyyyy" )]
    public DateTime ShippedDateUTC {
      get{ return ShippedDate.ToUniversalTime();}
    }
