    public Decimal MyDecimalProperty { get; set; }
    [RegexValidator(@"^\d{1,7}\.\d{2,7}$")]
    public string MyDecimalPropertyString
    {
        get
        {
            return this.MyDecimalProperty.ToString();
        }
    }
