    public string PartNumber
    {
        get
        {
            return this.PartId ?? this.ChildPartId;
        }
    }
    internal string PartId { get; set; }
    internal string ChildPartId { get; set; }
