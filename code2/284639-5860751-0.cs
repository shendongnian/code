        public string GetEntitiName<T>()
        {
            PropertyInfo propInfo = typeof(MyDatabaseContext).GetProperties().Where(p => p.PropertyType == typeof(DbSet<T>)).FirstOrDefault();
            string propertyName = propInfo.Name; //The string has the property name ..
            return propertyName;    
        }
  
