    public Reports ReportType { get; set; }
    [DataMember(Name = "listBoxID")]
    public string listBoxID 
    {
        set
        {
             ReportType = DetermineReportType(value);
        } 
