        public DataTable GetTablesWithUpperCaseName(string server, string database, 
                                                    string username, string password)
        {
            // Create the datatable
            DataTable dtListOfTablesWithUppercaseName = new DataTable("tableNames");
            SqlConnectionStringBuilder objConnectionString = new SqlConnectionStringBuilder();
            objConnectionString.DataSource = server;;
            objConnectionString.UserID = username;
            objConnectionString.Password = password;
            objConnectionString.InitialCatalog = database;
            // Define the Query against sys.tables - much easier and cleaner!
            string selectTablesWithUppercaseName =
                "SELECT NAME FROM sys.tables WHERE UPPER(name) COLLATE Latin1_General_BIN = name COLLATE Latin1_General_BIN AND is_msshipped = 0";
            // put your SqlConnection and SqlCommand into using blocks!
            using (SqlConnection sConnection = new SqlConnection(objConnectionString.ConnectionString))
            using (SqlCommand sCommand = new SqlCommand(selectTablesWithUppercaseName, sConnection))
            {
                try
                {
                    // Create the dataadapter object
                    SqlDataAdapter sDataAdapter = new SqlDataAdapter(selectTablesWithUppercaseName, sConnection);
                    // Fill the datatable - no need to open the connection, the SqlDataAdapter will do that all by itself 
                    // (and also close it again after it is done)
                    sDataAdapter.Fill(dtListOfTablesWithUppercaseName);
                }
                catch (Exception ex)
                {
                    //All the exceptions are handled and written in the EventLog.
                    EventLog log = new EventLog("Application");
                    log.Source = "MFDBAnalyser";
                    log.WriteEntry(ex.Message);
                }
            }
            // return the data table to the caller
            return dtListOfTablesWithUppercaseName;
        }
