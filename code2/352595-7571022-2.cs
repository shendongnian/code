    private IEnumerable<Resource> LoadStudents()
    {
        List<Resource> resources = new List<Resource>();
        using (DbConnection conn = OpenConnection())
        {
            DbCommand cmd = DbFactory.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT [StudentID], [Name] FROM [DbProvider_Students]";
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Resource res = new Resource();
                    res.Type = "Student";
                    res.Key = reader["StudentID"];
                    res.Text = Convert.ToString(reader["Name"]);
                    resources.Add(res);
                }
            }
        }
        return resources;
    }
