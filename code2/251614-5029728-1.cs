    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.UserResource)
                .AsSet()
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
    
    public class UserResourceMap : ClassMap<User>
    {
        public UserResourceMap()
        {
            Table("UserResourceMap");
            Id(x => x.Id);
            References(x => x.User).Not.Nullable();
            References(x => x.Resource).Not.Nullable();
            Map(x => x.AccessLevel);
        }
    }
    
    public class ResourceMap : ClassMap<Resource>
    {
        public ResourceMap()
        {
            Cache.ReadOnly();
    
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
