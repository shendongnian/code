    //The idea of the following code is to display the progress on a progressbar using the value returning from the SQL Server message. 
    //When done, it will show the final message on the textbox. 
    String connectionString = "Data Source=server;Integrated Security=SSPI;";
    SqlConnection sqlConnection = new SqlConnection(connectionString);
    
    public void DatabaseWork(SqlConnection con)
    {
    	con.FireInfoMessageEventOnUserErrors = true;
    	//con.InfoMessage += OnInfoMessage;
    	con.Open();
    	con.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e)
    	{
    		//Use textBox due to textBox has Invoke function. You can also utilize other way. 
    		this.textBox.Invoke(
    			(MethodInvoker)delegate()
    			{
    				int num1;
    				//Get the message from e.Message index 0 to the length of first ' '
    				bool res = int.TryParse(e.Message.Substring(0, e.Message.IndexOf(' ')), out num1);
    
    				//If the substring can convert to integer
    				if (res)
    				{
    					//keep updating progressbar
    					this.progressBar.Value = int.Parse(e.Message.Substring(0, e.Message.IndexOf(' ')));
    				}
    				else
    				{
    					//Check status from message 
    					int succ;
    					succ = textBox.Text.IndexOf("successfully");
    					//or succ = e.Message.IndexOf("successfully");	//get result from e.Message directly
    					if (succ != -1)	//If IndexOf find nothing, it will return -1
    					{
    						progressBar.Value = 100;
    						MessageBox.Show("Done!");
    					}
    					else
    					{
    						progressBar.Value = 0;
    						MessageBox.Show("Error, backup failed!");
    					} 
    				}
    			}
    		);
    	};
    	using (var cmd = new SqlCommand(string.Format(
    		"Your SQL Script"//,
    		//QuoteIdentifier(databaseName),
    		//QuoteString(Filename)//,
    		//QuoteString(backupDescription),
    		//QuoteString(backupName)
    		), con))
    	{
    		//Set timeout = 1200 seconds (equal 20 minutes, you can set smaller value for shoter time out. 
    		cmd.CommandTimeout = 1200;
    		cmd.ExecuteNonQuery();
    	}
    	con.Close();
    	//con.InfoMessage -= OnInfoMessage;
    	con.FireInfoMessageEventOnUserErrors = false;
    }
