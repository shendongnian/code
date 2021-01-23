        private static DataTable OpenTextFile()
        {
    #if X86 // 32-bit
            string _connectionStringTemplate = "Driver={{Microsoft Text Driver (*.txt; *.csv)}};Extensions=asc,csv,tab,txt;Persist Security Info=False;Dbq={0}";
    #else // 64-bit
            string _connectionStringTemplate = "Driver={{Microsoft Access Text Driver (*.txt, *.csv)}};Dbq={0};Extensions=asc,csv,tab,txt";
    #endif
    
                string connectionString = string.Format(_connectionStringTemplate, @"C:\Temp\");
    
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    string selectAll = string.Format("select * from [{0}]", Path.GetFileName("test.txt"));
    
                    using (OdbcCommand command = new OdbcCommand(selectAll, connection))
                    {
                        connection.Open();
    
                        DataTable dataTable = new DataTable("txt");
    
                        using (OdbcDataAdapter adapter = new OdbcDataAdapter(selectAll, connection))
                        {
                            //Fills dataset with the records from file
                            adapter.Fill(dataTable);
    
                            return dataTable;
                        }
                    }
                }
            }
