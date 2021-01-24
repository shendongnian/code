	using(SqlConnection con = new SqlConnection(.....)) 
    {
        con.Open();
        DataTable dt = new DataTable();
        // Get info on all tables...
        SqlCommand cmd = new SqlCommand(@"SELECT * FROM INFORMATION_SCHEMA.TABLES 
                                          WHERE TABLE_TYPE = 'BASE TABLE'", con);
        dt.Load(cmd.ExecuteReader());
        foreach (DataRow r in dt.Rows)
        {
            // Get info on the current table's columns
            string sqltext = $"SELECT * FROM INFORMATION_SCHEMA.Columns 
                               WHERE TABLE_NAME = '{r.Field<string>("TABLE_NAME")}'";
            SqlCommand cmd1 = new SqlCommand(sqltext, con);
            DataTable dt1 = new DataTable();
            dt1.Load(cmd1.ExecuteReader());
            foreach (DataRow x in dt1.Rows)
            {
                Console.WriteLine($"Table:{x.Field<string>("TABLE_NAME")}");
                Console.WriteLine($"Column:{x.Field<string>("COLUMN_NAME")}");
                Console.WriteLine($"Data type:{x.Field<string>("DATA_TYPE")}");
                Console.WriteLine($"Nullable:{x.Field<string>("IS_NULLABLE")}");
            }
        }
