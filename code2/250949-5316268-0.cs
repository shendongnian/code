    [System.Data.Linq.Mapping.Association(Storage = "profile", ThisKey = "UserId", OtherKey = "UserId")]
    public Profile User {
       get { return this.profile.Entity; }
       set { this.profile.Entity = value; }
    }
