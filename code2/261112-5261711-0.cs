    public class MemberOverride : IAutoMappingOverride<Member>
    {
        public void Override(AutoMapping<Member> mapping)
        {
            mapping.HasManyToMany(m => m.Friends)
                   .Table("MemberFriendsLinkTable");
        }
    }
