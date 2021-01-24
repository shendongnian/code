                builder.Entity<ApplicationUser>()
                        .HasMany(u => u.PublishedModels)
                        .WithOne(vv => vv.Publisher)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
