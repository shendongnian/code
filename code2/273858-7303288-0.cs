        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            BuildAspNetEntities(modelBuilder);
            // put method here that builds your own entities
            base.OnModelCreating(modelBuilder);
        }
        private void BuildAspNetEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasKey(a => a.ApplicationId).ToTable("aspnet_Applications");
            modelBuilder.Entity<UserInfo>().HasKey(ui => ui.UserId).ToTable("aspnet_Users");
            modelBuilder.Entity<UserInfo>()
                .HasRequired(ui => ui.MembershipInfo)
                .WithRequiredDependent(mi => mi.UserInfo);
            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.Roles).WithMany(r => r.UserMemberships)
                .Map(u =>
                    {
                        u.MapLeftKey("UserId");
                        u.MapRightKey("RoleId");
                        u.ToTable("aspnet_UsersInRoles");
                    });
            modelBuilder.Entity<MembershipInfo>().HasKey(ui => ui.UserId).ToTable("aspnet_Membership");
            modelBuilder.Entity<MembershipInfo>().Property(mi => mi.Comment).IsMaxLength();
            modelBuilder.Entity<Path>()
                .HasKey(p => p.PathId)
                .ToTable("aspnet_Paths");
            
            modelBuilder.Entity<PersonalizationAllUser>()
                .HasKey(pau => pau.PathId)
                .ToTable("aspnet_PersonalizationAllUsers");
            modelBuilder.Entity<PersonalizationAllUser>()
                .HasRequired(pau => pau.Path).WithOptional(p => p.PersonalizationAllUser);
            modelBuilder.Entity<PersonalizationPerUser>()
                .HasKey(ppu => ppu.Id)
                .ToTable("aspnet_PersonalizationPerUser");
            modelBuilder.Entity<Profile>()
                .HasKey(p => p.UserId)
                .ToTable("aspnet_Profile");
            modelBuilder.Entity<Profile>()
                .HasRequired(p => p.User).WithOptional(u => u.Profile);
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleId)
                .ToTable("aspnet_Roles");
            modelBuilder.Entity<SchemaVersion>()
                .HasKey(sv => new { sv.Feature, sv.CompatibleSchemaVersion })
                .ToTable("aspnet_SchemaVersions");
            modelBuilder.Entity<WebEvent_Event>()
                .HasKey(we => we.EventId)
                .ToTable("aspnet_WebEvent_Events");
        }
