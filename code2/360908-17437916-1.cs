    class webpages_OAuthMembershipEntities : DbContext
    {
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            var config = modelBuilder.Entity<OAuthMembership>();
            config.ToTable( "webpages_OAuthMembership" );            
        }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }        
    }
