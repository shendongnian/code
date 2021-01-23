    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId).GeneratedBy.Identity();
            Map(x => x.UserName).Length(DataConstants.UserNameLength).Unique().Not.Nullable();
            Map(x => x.EmailAddress).Length(DataConstants.EmailAddressLength).Unique().Not.Nullable();
            Map(x => x.DateJoined).Not.Nullable();
            Map(x => x.Password).Length(DataConstants.PasswordHashLength).Not.Nullable();
            HasManyToMany(x => x.UserRoles).Cascade.AllDeleteOrphan().AsBag().Table("UsersInRole");
            HasManyToMany(x => x.SubscribedFeeds).Cascade.DeleteOrphan().AsBag().Table("Subscriptions");
            HasManyToMany(x => x.OwnedFeeds).Cascade.All().AsBag().Table("FeedOwners");
            HasMany(x => x.Reads).Cascade.AllDeleteOrphan().Fetch.Join().Inverse().KeyColumn("UserId");
        }
    }
