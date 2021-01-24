    class Ministry
    {
        public int Id {get; set;}
        public string Name {get; set;}
        // every Ministry has zero or more MemberGroups (one-to-many)
        public virtual ICollection<MemberGroup> MemberGroups {get; set;}
    }
    class MemberGroup
    {
        public int Id {get; set;}
        public string Name {get; set;}
        // every MemberGroup belongs to exactly one Ministry, using foreign key
        public int MinistryId {get; set;}
        public virtual Ministry Ministry {get; set;}
    }
    public MyDbContext : DbContext
    {
        public DbSet<Ministry> Ministries {get; set;}
        public DbSet<MemberGroup> MemberGroups {get; set;}
    }
