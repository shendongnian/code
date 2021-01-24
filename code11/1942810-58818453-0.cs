    string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"data source =ElevatorLog.accdb";
    string dbcommand = @"insert into [Elevator] 
           ([MovingAction],[TimeAction]) 
           values 
           (@movingaction, @timeaction)";
    
    
    //?        listBox1.Items.Add(movingaction + "\t\t" + timeaction + "\t\t");
    
    using (OleDbConnection conn_db = new OleDbConnection(dbconnection))
    using (OleDbCommand comm_insert = new OleDbCommand(dbcommand, conn_db))
    {
       comm_insert.Parameters.Add("@timeaction", OleDbType.DBDate).Value = DateTime.Now;
       comm_insert.Parameters.Add("@movingaction", OleDbType.DBDate).Value = movingaction; // not sure if this is DateTime
    
      conn_db.Open();
      comm_insert.ExecuteNonQuery();
      conn_db.Close();
    }
