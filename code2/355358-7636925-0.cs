    [XmlElement("EndDate")]
    public DateTime? EndDate { get; set; }
    [XmlIgnore]
    public bool EndDateSpecified { get {
        return (EndDate != null && EndDate.HasValue); } }
