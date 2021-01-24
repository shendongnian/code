    [IgnoreDataMember]
    public DateTime Date { get; set; }
    [DataMember(name="Date")]
    private string Date_asString
    {
        get
        {
            return Date.ToString("yyyy-MM-dd(HH:mm)");
        }
        set
        {
            Date = DateTime.Parse(value);
        }
     }
