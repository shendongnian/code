    public class UserAccountMap : ClassMap<UserAccount>
    {
        public UserAccountMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned(); // cannot use identity generator with union-subclass mapping
    
            References(x => x.User)
               .Column("UserId");
    
            this.UseUnionSubclassForInheritanceMapping(); // tell FNH that you are using table per concrete class mapping
        }
    }
