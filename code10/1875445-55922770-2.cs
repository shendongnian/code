    IDictionary<string, string> UserTableColumns = new Dictionary<string, string>() {
                {"Id",  "lngUserID"}, {"Email",  "strUserEmail"},{"EmailConfirmed", "strUserEmailConfirmed"}};
    
                foreach (var property in typeof(ApplicationUser).GetProperties())
                {
                    if (UserTableColumns.ContainsKey(property.Name))
                    {
                        builder.Entity<ApplicationUser>().Property(property.Name).HasColumnName(property.Name);
                    }
                }
