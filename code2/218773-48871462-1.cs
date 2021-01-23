            public IList<Tuple<string, string>> ListTables()
            {
            
                DataTable dt = con.GetSchema("Tables");
                var tables = new List<Tuple<string, string>>();
                
                foreach (DataRow row in dt.Rows)
                {
                string schemaName = (string)row[1];
                string tableName = (string)row[2];
                //AddToList();
                tables.Add(Tuple.Create(schemaName, tableName));
                Console.WriteLine(schemaName +" " + tableName) ;
                }
                return tables;
            }
