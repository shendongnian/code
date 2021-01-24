    dbConn.Open();// this allows you to edit the database
    
    string sql = "Select * from database1";
    
    SqlCommand dbComm = new SqlCommand(sql, dbConn);
    
    SqlDataAdapter dbAdapter = new SqlDataAdapter(dbComm);
    
    DataTable dt = new DataTable();
    
    dbAdapter.Fill(dt);
    
    cmbDescription.DataSource = dt;
    
    cmbDescription.DisplayMember = "itemName";
    
    cmbDescription.ValueMember = "Enter the column name here";
    
    cmbDescription.Text = "";
    
    cmbDescription.Items.Add(dt);
    
    cdbConn.Close(); //close connection to save all your inputs,calculations to the database
    
        
