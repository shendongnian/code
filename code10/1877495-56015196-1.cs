		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            
            //extracted m:n mapping for demonstration puporses
			builder.Entity<AppUserRole>(userRole =>
			{
				userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
				userRole.HasOne(ur => ur.Role)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();
				userRole.HasOne(ur => ur.User)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.UserId)
					.IsRequired();
			});
			builder.ApplyConfiguration(new AppUserConfiguration());
			builder.ApplyConfiguration(new MapConfigConfiguration());
			builder.ApplyConfiguration(new MapWidgetConfiguration());
			builder.ApplyConfiguration(new WidgetConfiguration());
			builder.ApplyConfiguration(new LayoutMenuConfiguration());
			builder.ApplyConfiguration(new ImageConfiguration());
			builder.ApplyConfiguration(new FrontPageContentConfiguration());
		}
	}
