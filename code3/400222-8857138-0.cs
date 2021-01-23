    public int Id { get; set; }      
      
    // snip...      
      
    // Foreign Key      
    public string ProjectId { get; set; }      
      
    // navigation proeprty      
    public virtual IProjectType ProjectType { get; set; }      
