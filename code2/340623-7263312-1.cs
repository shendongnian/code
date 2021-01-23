        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Composite key definition
            modelBuilder.Entity<RegionalInfo>().HasKey(x => new { x.ContentId, x.RegionId });
            // And if I remember correctly this was required in order to do
            // var x = contentObject.RegionalInfo.Where(....) stuff
            modelBuilder.Entity<RegionalInfo>().HasRequired<Content>(x => x.Content).WithMany(x => x.RegionalInfo).HasForeignKey(x => x.ContentId);
        }
