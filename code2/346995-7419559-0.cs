    public Action<object,EventArgs> onMyButtonClick { get; set; }
    
    ...
    
    void btn_Click(object sender, EventArgs e)
    {
        onMyButtonClick(sender, e);
    }
    
