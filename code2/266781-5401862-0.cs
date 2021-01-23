    private void btnListTables_Click(object sender, EventArgs e)
    
    {
    
          if (OdbcCon.State == ConnectionState.Open)
    
          {
    
                // Execute the SHOW TABLES query on the MySQL database
    
                OdbcCom = new System.Data.Odbc.OdbcCommand("SHOW TABLES", OdbcCon);
    
                OdbcDR = OdbcCom.ExecuteReader();
    
                txtLog.AppendText("Tables inside " + txtDatabase.Text + ":\r\n");
    
                // Loop through the list of tables and display each one
    
                while (OdbcDR.Read())
    
                {
    
                      txtLog.AppendText(">> " + OdbcDR[0] + "\r\n");
    
                }
    
          }
    
    }
