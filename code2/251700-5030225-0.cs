           try
            {
                // Construct an object of the OleDbConnection 
                // class to store the connection string 
                // representing the type of data provider 
                // (database) and the source (actual db)
                string sConnection =
                    "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=C:\\Code\\StackOverflowSamples\\ReadFromAccessDB\\employee.mdb";
                using (OleDbConnection dbConn = new OleDbConnection(sConnection))
                {
                    dbConn.Open();
                    // Construct an object of the OleDbCommand 
                    // class to hold the SQL query. Tie the  
                    // OleDbCommand object to the OleDbConnection
                    // object
                    string sql = "Select * From employee";
                    OleDbCommand dbCmd = new OleDbCommand();
                    dbCmd.CommandText = sql;
                    dbCmd.Connection = dbConn;
                    // Create a dbReader object 
                    using (OleDbDataReader dbReader = dbCmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            Console.WriteLine(dbReader["EmployeeName"].ToString());
                            Console.WriteLine(dbReader["Address"].ToString());
                            Console.WriteLine(dbReader["SSN"].ToString());
                            Console.WriteLine(dbReader["Rate"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("exeption" + ex.ToString());
            }
            Console.ReadLine();
        }
