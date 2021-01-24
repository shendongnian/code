    IDictionary<string, string> UserTableColumns = new Dictionary<string, string>() {
                {"Id",  "lngUserID"}, {"Email",  "strUserEmail"},{"EmailConfirmed", "strUserEmailConfirmed"}};
    
                foreach (var property in typeof(User).GetProperties())
                {
                    if (UserTableColumns.ContainsKey(property.Name))
                    {
                        builder.Entity<User>().Property(property.Name).HasColumnName(property.Name);
                    }
                }
