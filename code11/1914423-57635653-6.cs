    public int Page { get; set; }    
    public void Validate()
    {
        if(Page < 0)
           Page = 0;
    }
