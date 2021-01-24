    public enum DbObjectType
    {
        SYSTEM_TABLE,
        USER_TABLE,
        VIEW,
        SQL_STORED_PROCEDURE
    }
    public class SqlServerDbObjects
    {
        const string connectionString = @"Data Source=.\;Initial Catalog=master;Integrated Security=True";
        public IDictionary<string, IList<string>> GetDbObjects()
        {
            var dbNameList = GetDatabaseList();
    
            var dbObj = new Dictionary<string, IList<string>>();
    
            for (int x = 0; x < dbNameList.Count; x++)
            {
                var name = dbNameList[x];
    
                var objList = GetDatabaseObjectsList(name, DbObjectType.USER_TABLE);
    
                dbObj.Add(name, objList);
            }
    
            return dbObj;
    
        }
        public IList<string> GetDatabaseList()
        {
            const string sql = "SELECT [name] FROM sys.databases WHERE database_id > 4";
    
            return Reader(sql, "name");
        }
        public IList<string> GetDatabaseObjectsList(string databaseName, DbObjectType objType)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
    
            if (string.IsNullOrEmpty(databaseName))
                throw new NullReferenceException("You must specify a database");
            else
                sb.Append($"SELECT [name] FROM [{databaseName}].sys.objects WHERE [type_desc] = '{objType.ToString()}'");
    
            return Reader(sb.ToString(), "name");
        }
        public IList<string> Reader(string query, string columnName)
        {
            var list = new List<string>();
    
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
    
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            list.Add(dataReader[columnName].ToString());
                        }
                    }
    
    
                }
    
                return list;
            }
            catch (SqlException ex)
            {
                // do stuff for handling sql errors.
                return null;
            }
        }
    
    }
