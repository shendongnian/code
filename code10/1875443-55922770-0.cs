    IDictionary<string, string> UserTableColumns = new Dictionary<string, string>() {
                        {"Id",  "lngUserID"}, {"Email",  "strUserEmail"},{"EmailConfirmed", "strUserEmailConfirmed"}};
        
            
                        var userEntityType = builder.Model.GetOrAddEntityType("Table");
                        var userEntityTypeInfo = userEntityType.ClrType.GetTypeInfo();
            
                        foreach (var property in userEntityType.GetProperties())
                        {
        //update the column if it is found in the defined dictionary
                            if (UserTableColumns.ContainsKey(property.Name))
                            {
                                property.Relational().ColumnName = UserTableColumns[property.Name];
                            }
                        }
