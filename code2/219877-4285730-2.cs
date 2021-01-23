    public void GetPrimaryKeyTable() {
    	//An instance of the connection string is created to manage the contents of the connection string.
    
    	var sqlConnection = new SqlConnectionStringBuilder();
    	sqlConnection.DataSource = "192.168.10.3";
    	sqlConnection.UserID = "gp";
    	sqlConnection.Password = "gp";
    	sqlConnection.InitialCatalog = Convert.ToString(cmbDatabases.SelectedValue);
    	
    	// Automatically close the connection
    	using(SqlConnection sConnection = new SqlConnection(sqlConnection.ConnectionString)) {
    		try {
    			sConnection.Open();
    
    			//Query to select the table_names that have PRIMARY_KEYS.
    			string selectPrimaryKeys = @"SELECT	TABLE_NAME 
    										FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    										WHERE	CONSTRAINT_TYPE = 'PRIMARY KEY'
    										ORDER 	BY TABLE_NAME";
    
    			//Create the command object
    			using(SqlCommand sCommand = new SqlCommand(selectPrimaryKeys, sConnection)) {
    				// Bind the combobox without destroying the data reader object after binding (no using statement)
    				cmbResults.DisplayMember = "TABLE_NAME";
    				cmbResults.ValueMember = "TABLE_NAME";	
    				cmbResults.DataSource sReader = sCommand.ExecuteReader();
    				cmbResults.DataBind();
    			}
    		}
    		catch(Exception ex) {
    			// All the exceptions are handled and written in the EventLog.
    			EventLog log = new EventLog("Application");
    			log.Source = "MFDBAnalyser";
    			log.WriteEntry(ex.Message);
    		}
    		finally {
    			// Read somewhere that the using statement takes care of this for you
    			// but just in case
    			if(sConnection.State != ConnectionState.Closed) {
    				sConnection.Close();
    			}
    		}
    	}
    }
