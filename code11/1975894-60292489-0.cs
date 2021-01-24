    private void AddNewDataRow(DataTable dt)
    {
       try
       {  
          DataRow drNew = dt.NewRow();
          dt.Rows.Add(drNew);
          // 
          // .. doing other stuff that throws and error before AcceptChange is called
          //
          dt.AcceptChanges();
       }
       Catch()
       {
          //RollBack Because an error occurred
          dt.RejectChanges();
       }
    }
