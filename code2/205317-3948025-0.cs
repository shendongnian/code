        public AccountabilityMap()
        {
            Schema("organizationstructure");
            Not.LazyLoad();
            Id(p => p.Id);
            References(p => p.AccountabilityType)
                .Not.Nullable();
            References(p => p.Child)
                .Column("ChildPartyId")
                .Not.LazyLoad()
                .Not.Nullable();
            References(p => p.Parent)
                .Column("ParentPartyId")
                .Not.LazyLoad()
                .Not.Nullable();
        }
    } 
