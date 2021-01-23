            OdbcConnection conn = new OdbcConnection("DSN=Stack");
            conn.Open();
            OdbcCommand foo = new OdbcCommand(@"SELECT * FROM [stack.csv]",conn);
            IDataReader dr = foo.ExecuteReader();
            while (dr.Read())
            {
                List<string> data = new List<string>();
                int cols = dr.GetSchemaTable().Rows.Count;
                for (int i=0; i<cols; i++)
                {
                    System.Diagnostics.Debug.WriteLine(dr[i].ToString());
                }
            }
