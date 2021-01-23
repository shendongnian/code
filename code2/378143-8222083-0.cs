    public string CreatedBy
    {
        get;
        private set;
    }
    public DateTime? Created
    {
        get;
        private set;
    }
    public Model(..., string createdBy)
    {
        this.CreatedBy = createdBy;
        this.Created = DateTime.Now;
    }
    // another option, if you don't like the ctor route
    public void AssignCreator(string createdBy)
    {
        if (this.Created.HasValue) throw new InvalidOperationException();
        this.CreatedBy = createdBy;
        this.Created = DateTime.Now;
    }
