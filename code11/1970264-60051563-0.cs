csharp
System.Reflection.PropertyInfo[] props = typeof(MyTable).GetProperties();
            foreach (var prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DatabaseAttribute dbAttr = attr as DatabaseAttribute;
                    if (dbAttr != null)
                    {
                        string propName = prop.Name;
                        System.Version minVersion = new System.Version(dbAttr.MinVersion);
                        if (databaseVersion < minVersion)
                        {
                            // The database doesn't know about this property, ignore it
                            modelBuilder.Entity<MyTable>().Ignore(prop.Name);
                        }
                    }
                }
            }
Or you can build the expression dynamically
csharp
System.Reflection.PropertyInfo[] props = typeof(MyTable).GetProperties();
            foreach (var prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DatabaseAttribute dbAttr = attr as DatabaseAttribute;
                    if (dbAttr != null)
                    {
                        string propName = prop.Name;
                        System.Version minVersion = new System.Version(dbAttr.MinVersion);
                        if (databaseVersion < minVersion)
                        {
                            // The database doesn't know about this property, ignore it
                            modelBuilder.Entity<MyTable>().Ignore(Expression.Property(Expression.Parameter(typeof(MyTable)),prop));
                        }
                    }
                }
            }
