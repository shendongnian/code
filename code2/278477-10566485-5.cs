    public class Initializer : IDatabaseInitializer<myEntities>
            {
                public void InitializeDatabase(myEntities context)
                {
                    if (System.Diagnostics.Debugger.IsAttached && context.Database.Exists() && !context.Database.CompatibleWithModel(false))
                    {
                        context.Database.Delete();
                    }
    
                    if (!context.Database.Exists())
                    {
                        context.Database.Create();
    
                        var contextObject = context as System.Object;
                        var contextType = contextObject.GetType();
                        var properties = contextType.GetProperties();
                        System.Type t = null;
                        string tableName = null;
                        string fieldName = null;
                        foreach (var pi in properties)
                        {
                            if (pi.PropertyType.IsGenericType && pi.PropertyType.Name.Contains("DbSet"))
                            {
                                t = pi.PropertyType.GetGenericArguments()[0];
    
                                var mytableName = t.GetCustomAttributes(typeof(TableAttribute), true);
                                if (mytableName.Length > 0)
                                {
                                    TableAttribute mytable = mytableName[0] as TableAttribute;
                                    tableName = mytable.Name;
                                }
                                else
                                {
                                    tableName = pi.Name;
                                }
    
                                foreach (var piEntity in t.GetProperties())
                                {
                                    if (piEntity.GetCustomAttributes(typeof(UniqueAttribute), true).Length > 0)
                                    {
                                        fieldName = piEntity.Name;
                                        context.Database.ExecuteSqlCommand("ALTER TABLE " + tableName + " ADD CONSTRAINT con_Unique_" + tableName + "_" + fieldName + " UNIQUE (" + fieldName + ")");
                                    }
                                }
                            }
                        }
                    }
                }
            }
 
