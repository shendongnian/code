    public string submit { get; set; }
    
    public bool SaveButtonClicked()
    {
        return this.submit.Equals("save");
    }
    
    public bool CancelButtonClicked()
    {
        return this.submit.Equals("cancel");
    }
