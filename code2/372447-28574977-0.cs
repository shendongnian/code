    public int CompanyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual Company Company { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
