    public void ProcessMessageRows()
    // finds the first row that has not been sent
    {
          // skipping some code
           while (drGetMessageRow.Read())
            {
             // while loop does not understand the variable and errors  
                int rowID = drGetMessageRow.GetInt32(0);
                MessageBox.Show("1: RowID is " + rowID.ToString());
                RunStoredProcedure(rowId);
            }
    }
