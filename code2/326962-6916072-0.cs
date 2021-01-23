    private void EnableEvent(int eventID)
    {
        OleDbConnection myConn = new OleDbConnection(myConnString);
        myConn.Open();
        OleDbCommand myCommand = myConn.CreateCommand();
        OleDbTransaction myTrans;
        // Start a local transaction
        myTrans = myConn.BeginTransaction();
       // Assign transaction object for a pending local transaction
        myCommand.Connection = myConn;
        myCommand.Transaction = myTrans;
        
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE Events SET isActive = 1 where EventID='{0}'", eventID);
            myCommand.CommandText = sql.ToString();
            // insert the header
            myCommand.ExecuteNonQuery();
            myTrans.Commit();
        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message, "Database Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        finally
        {
            myCommand.Connection.Close();
            myCommand.Dispose();
        }
    }
