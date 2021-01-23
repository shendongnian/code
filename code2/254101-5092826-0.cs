    [BrowsableAttribute(True)]
    [DefaultValue("true")]
    public bool IsNew { get; set; }
    protected void Page_Init(object sender, EventArgs e)
    {
        btnAdd = IsNew;
    }
