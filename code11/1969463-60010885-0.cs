    builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper() },
            new IdentityRole { Id = 2, Name = "PoUser", NormalizedName = "PoUser".ToUpper() },
            new IdentityRole { Id = 3, Name = "User", NormalizedName = "User".ToUpper() }
        );
