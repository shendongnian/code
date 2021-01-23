    public class AccountabilityTypeMap : ClassMap<AccountabilityType>
    {
        public AccountabilityTypeMap()
        {
            Id(p => p.Id).GeneratedBy.Assigned();
        }
    }
    public class AccountabilityMap : ClassMap<Accountability>
    {
        public AccountabilityMap()
        {
            Id(p => p.Id).GeneratedBy.Guid();
            References(p => p.Parent, "ParentId").Cascade.None();
            References(p => p.Child, "ChildId").Cascade.All();
            References(p => p.Type, "AccountabilityTypeId").Cascade.None();
        }
    }
    public class PartyMap : ClassMap<Party>
    {
        public PartyMap()
        {
            Id(p => p.Id).GeneratedBy.Guid();
            
            Map(p => p.Name);
            
            Map(p => p.Type);
            HasMany(p => p.ChildAccountabilities)
                .KeyColumn("ParentId")
                .Inverse()
                .Cascade.All();
            HasMany(p => p.ParentAccountabilities)
                .KeyColumn("ChildId")
                .Inverse()
                .Cascade.All();
        }
    }
