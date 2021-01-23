    static string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                  Data Source=x:\full_path\dbMert.mdb";
---------------
    static class Test
    {
        static string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbMert.mdb";
        public static DataTable executeSelect(string sql)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql,connectionString);
            adapter.Fill(dt);
            return dt;
        }
    }
