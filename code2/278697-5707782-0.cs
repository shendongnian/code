    public CacheDependency GetRoleActionCacheDependency()
        {
            using (var connection = new SqlConnection(Database.Database.Connection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sc = new SqlCommand("select roleid, actionid from dbo.RoleAction", connection))
                {
                    var dependency = new SqlCacheDependency(sc);
                    sc.ExecuteNonQuery();
                    connection.Close();
                    return dependency;
                }
            }
        }
