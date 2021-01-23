    public class ColumnAndDefault
    {
        public string ColumnName { get; set; }
        public string DefaultDefinition { get; set; }
    }
    public class GetDefaultColumnValues
    {
        public List<ColumnAndDefault> GetDefaultsForTable(string tablename, string connectionString)
        {
            List<ColumnAndDefault> results = new List<ColumnAndDefault>();
            string query =
                string.Format("SELECT name, object_definition(default_object_id) " +
                "FROM sys.columns " +
                "WHERE default_object_id <> 0 AND object_id = OBJECT_ID('{0}')", tablename);
            using(SqlConnection _con = new SqlConnection(connectionString))
            using(SqlCommand _cmd = new SqlCommand(query, _con))
            {
                _con.Open();
                using(SqlDataReader rdr = _cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        string colName = rdr.GetString(0);
                        string defValue = rdr.GetString(1);
                        results.Add(
                             new ColumnAndDefault { ColumnName = colName, 
                                                    DefaultDefinition = defValue });
                    }
                    rdr.Close();
                }
                _con.Close();
            }
            return results;
        }
    }
