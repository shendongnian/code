    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; Created = Created ?? DateTime.Now; }
    }
    public DateTime? Created { get; set; }
