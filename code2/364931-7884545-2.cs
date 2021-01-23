    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public MoreDetails ExtendedDetails { get; set; }
    }
    public class MoreDetails
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public User User { get; set; } // Foreign key in the DB
    } 
    public UserMapping()
    {
        Not.LazyLoad();
        Id(e => e.ID).GeneratedBy.Identity();
        Map(e => e.Username).Not.Nullable();
        HasOne(x => x.ExtendedDetails)
            .Cascade
            .SaveUpdate();
    }
    public MoreDetailsMapping()
    {
        Not.LazyLoad();
        Id(e => e.ID).GeneratedBy.Identity();
        Map(e => e.Firstname).Not.Nullable();
        References(x => x.User).Column("UserID");
    }
