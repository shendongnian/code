    public int GetMessageRow()
    // finds the first row that has not been sent
    {
        int rowID;
          // skipping some code
           while (drGetMessageRow.Read())
            {
             // while loop does not understand the variable and errors  
                rowID = drGetMessageRow.GetInt32(0);
                MessageBox.Show("1: RowID is " + rowID.ToString());
            }
    
        return rowID;
    }
