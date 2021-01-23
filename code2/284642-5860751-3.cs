        public string GetEntitiName<T>() where T : class
        {
            PropertyInfo propInfo = typeof(MyDatabaseContext).GetProperties().Where(p => p.PropertyType == typeof(DbSet<T>)).FirstOrDefault();
            string propertyName = propInfo.Name; //The string has the property name ..
            return propertyName;    
        }
  
