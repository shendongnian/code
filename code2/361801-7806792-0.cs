    [Column(TypeName = "xml")]
    public string ProfileData
    { 
        get { return Profile.SerializeXml(); }
        set { Profile = value.DeserializeXml<Profile>(); }
    }
    
    [NotMapped]
    public Profile Profile { get; set; }
