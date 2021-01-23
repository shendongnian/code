    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    namespace YourNameSpace
    {
    	public enum SqlOption
        {
    		Active = 1,
    		GetDate = 2,
    		Index = 3,
            Unique = 4,
        }
    
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
        public class SqlAttribute : Attribute
        {
            public SqlAttribute(SqlOption selectedOption = SqlOption.Index)
            {
                this.Option = selectedOption;
            }
      
            public SqlOption Option {get; set;}
        }
    
        // See enum above, usage examples: [Sql(SqlOption.Unique)] [Sql(SqlOption.Index)] [Sql(SqlOption.GetDate)]
        public class SqlInitializer<T> : IDatabaseInitializer<T> where T : DbContext
        {
            // Create templates for the DDL we want generate
            const string INDEX_TEMPLATE = "CREATE NONCLUSTERED INDEX IX_{columnName} ON [dbo].[{tableName}] ([{columnName}]);";
            const string UNIQUE_TEMPLATE = "CREATE UNIQUE NONCLUSTERED INDEX UQ_{columnName} ON [dbo].[{tableName}] ([{columnName}]);";
            const string GETDATE_TEMPLATE = "ALTER TABLE [dbo].[{tableName}] ADD DEFAULT (getdate()) FOR [{columnName}];";
            const string ACTIVE_TEMPLATE = "ALTER TABLE [dbo].[{tableName}] ADD DEFAULT (1) FOR [{columnName}];";
    
            // Called by Database.SetInitializer(new IndexInitializer< MyDBContext>()); in MyDBContext.cs
            public void InitializeDatabase(T context)
            {
                // To be used for the SQL DDL that I generate
                string sql = string.Empty;
    
                // All of my classes are derived from my base class, Entity
                var baseClass = typeof(Entity);
    
                // Get a list of classes in my model derived from my base class
                var modelClasses = AppDomain.CurrentDomain.GetAssemblies().ToList().
                    SelectMany(s => s.GetTypes()).Where(baseClass.IsAssignableFrom);
    
                // For debugging only - examine the SQL DDL that Entity Framework is generating
    			// Manipulating this is discouraged.
                var generatedDDSQL = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
    
                // Define which Annotation Attribute we care about (this class!)
                var annotationAttribute = typeof(SqlAttribute);
    
                // Generate a list of concrete classes in my model derived from
                // Entity class since we follow Table Per Concrete Class (TPC).
                var concreteClasses = from modelClass in modelClasses
                                      where !modelClass.IsAbstract
                                      select modelClass;
    
                // Iterate through my model's concrete classes (will be mapped to tables)
                foreach (var concreteClass in concreteClasses)
                {
                    // Calculate the table name - could get the table name from list of DbContext's properties
                    // to be more correct (but this is sufficient in my case)
                    var tableName = concreteClass.Name + "s";
    
                    // Get concrete class's properties that have this annotation
                    var propertiesWithAnnotations = concreteClass.GetProperties().Where(prop => Attribute.IsDefined(prop, annotationAttribute));
    
                    foreach (var annotatedProperty in propertiesWithAnnotations)
                    {
                        var columnName = annotatedProperty.Name;
                        var annotationProperties = annotatedProperty.GetCustomAttributes(annotationAttribute, true).ToList();
    
                        foreach (SqlAttribute annotationProperty in annotationProperties)
                        {
    						// Generate the appropriate SQL DLL based on the attribute selected
                            switch (annotationProperty.Option)
    						{
                                case SqlOption.Active: // Default value of true plus an index (for my case)
                                    sql += ACTIVE_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
    								sql += INDEX_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
                                    break;
    							case SqlOption.GetDate: // GetDate plus an index (for my case)
    								sql += GETDATE_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
    								sql += INDEX_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
    								break;
    							case SqlOption.Index: // Default for empty annotations for example [Sql()]
    								sql += INDEX_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
    								break;
                                case SqlOption.Unique:
                                    sql += UNIQUE_TEMPLATE.Replace("{tableName}", tableName).Replace("{columnName}", columnName);
                                    break;
                            } // switch
                        } // foreach annotationProperty
                    } // foreach annotatedProperty
                } // foreach concreteClass
    
                // Would have been better not to go through all the work of generating the SQL
                // if we weren't going to use it, but putting it here makes it easier to follow.
                if (context.Database.CreateIfNotExists())
    				context.Database.ExecuteSqlCommand(sql);
    
            } // InitializeDatabase
        } // SqlInitializer
    } // Namespace
