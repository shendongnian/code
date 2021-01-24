        public DbSet<DepartmentActivity> DepartmentActivities { get; set; }
            modelBuilder.Entity<DepartmentActivity>().HasKey(x => new { x.ActivityId, x.DepartmentId});
            modelBuilder.Entity<DepartmentActivity>()
                .HasOne(x => x.Activity).WithMany(x => x.Departments );
            modelBuilder.Entity<DepartmentActivity>()
                .HasOne(x => x.Department).WithMany(x => x.Activities);
