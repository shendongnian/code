    [ReadOnly(true)]
    [XmlElement("TransactionRequestDt")]
    public string TransactionRequestDtString
    {
        get
        {
            return String.Format("{0:yyyy-MM-dd}", this.TransactionRequestDt);
        }
        set{}
    }`
