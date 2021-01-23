    public Action<object,EventArgs> onMyButtonClick { get; set; }
    
    ...
    protected void Page_Load(object sender, EventArgs e)
    {    
        btn.Click += (s,ea) => { onMyButtonClick(sender, e); };
    }    
    
