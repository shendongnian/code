    public class IdentityUserRole<TKey> where TKey : IEquatable<TKey>
    {
        public IdentityUserRole();
        //
        // Summary:
        //     Gets or sets the primary key of the user that is linked to a role.
        public virtual TKey UserId { get; set; }
        //
        // Summary:
        //     Gets or sets the primary key of the role that is linked to the user.
        public virtual TKey RoleId { get; set; }
    }
