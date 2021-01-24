    public string EndDate { get; set; }
    [XmlIgnore]
    public bool? _EndDate
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(EndDate))
            {
               return bool.Parse(EndDate);
            }
               return null;
        }
    }
