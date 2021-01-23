    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class IndexAttribute : Attribute
    {
        public IndexAttribute(string name, bool unique = false)
        {
            this.Name = name;
            this.IsUnique = unique;
        }
    
        public string Name { get; private set; }
    
        public bool IsUnique { get; private set; }
    }
    
    public class IndexInitializer<T> : IDatabaseInitializer<T> where T : DbContext
    {
        private const string CreateIndexQueryTemplate = "CREATE {unique} INDEX {indexName} ON {tableName} ({columnName});";
    
        public void InitializeDatabase(T context)
        {
            const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;
            Dictionary<IndexAttribute, List<string>> indexes = new Dictionary<IndexAttribute, List<string>>();
            string query = string.Empty;
    
            foreach (var dataSetProperty in typeof(T).GetProperties(PublicInstance).Where(p => p.PropertyType.Name == typeof(DbSet<>).Name))
            {
                var entityType = dataSetProperty.PropertyType.GetGenericArguments().Single();
                TableAttribute[] tableAttributes = (TableAttribute[])entityType.GetCustomAttributes(typeof(TableAttribute), false);
    
                indexes.Clear();
                string tableName = tableAttributes.Length != 0 ? tableAttributes[0].Name : dataSetProperty.Name;
    
                foreach (PropertyInfo property in entityType.GetProperties(PublicInstance))
                {
                    IndexAttribute[] indexAttributes = (IndexAttribute[])property.GetCustomAttributes(typeof(IndexAttribute), false);
                    NotMappedAttribute[] notMappedAttributes = (NotMappedAttribute[])property.GetCustomAttributes(typeof(NotMappedAttribute), false);
                    if (indexAttributes.Length > 0 && notMappedAttributes.Length == 0)
                    {
                        ColumnAttribute[] columnAttributes = (ColumnAttribute[])property.GetCustomAttributes(typeof(ColumnAttribute), false);
    
                        foreach (IndexAttribute indexAttribute in indexAttributes)
                        {
                            if (!indexes.ContainsKey(indexAttribute))
                            {
                                indexes.Add(indexAttribute, new List<string>());
                            }
    
                            if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                            {
                                string columnName = columnAttributes.Length != 0 ? columnAttributes[0].Name : property.Name;
                                indexes[indexAttribute].Add(columnName);
                            }
                            else
                            {
                                indexes[indexAttribute].Add(property.PropertyType.Name + "_" + GetKeyName(property.PropertyType));
                            }
                        }
                    }
                }
    
                foreach (IndexAttribute indexAttribute in indexes.Keys)
                {
                    query += CreateIndexQueryTemplate.Replace("{indexName}", indexAttribute.Name)
                                .Replace("{tableName}", tableName)
                                .Replace("{columnName}", string.Join(", ", indexes[indexAttribute].ToArray()))
                                .Replace("{unique}", indexAttribute.IsUnique ? "UNIQUE" : string.Empty);
                }
            }
                
            if (context.Database.CreateIfNotExists())
            {
                context.Database.ExecuteSqlCommand(query);
            }
        }
    
        private string GetKeyName(Type type)
        {
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttribute(typeof(KeyAttribute), true) != null)
                    return propertyInfo.Name;
            }
            throw new Exception("No property was found with the attribute Key");
        }
    }
