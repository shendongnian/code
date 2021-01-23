    using L2SAssociation = System.Data.Linq.Mapping.Association;
    [L2SAssociation(Storage = "profile", ThisKey = "UserId", OtherKey = "UserId")]
    public Profile User
    {
       get { return this.profile.Entity; }
       set { this.profile.Entity = value; }
    }
