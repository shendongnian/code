    [NotMapped]
    public RequestActionEnum Name
    {
         get { return (RequestActionEnum)NameValue; }
         set { NameValue = (int)value; }
    }
    [Column("Name")]
    public int NameValue { get; set; }
