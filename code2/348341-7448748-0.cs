    public decimal Length { get; set; }
    public string FormattedLength
    {
        get
        {
            return String.Format("{0:0.00}", this.Length);
        }
    }
