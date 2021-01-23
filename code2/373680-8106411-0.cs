    public List<string> GetItemName(int PersonID)
    {
         List<string> returnvalues = new List<string>();
         SqlCommand myCommand = new SqlCommand("GetItem", _productConn);
         myCommand.CommandType = CommandType.StoredProcedure;
         myCommand.Parameters.Add(new SqlParameter("@PERSON", SqlDbType.Int));
         myCommand.Parameters[0].Value = PersonID;
    
         _productConn.Open();
       DataReader dr= myCommand.ExecuteReader(); 
       While(dr.Reade() )  
      {
            returnvalues.Add(dr[0].ToString()); 
      }         
         _productConn.Close();
         return returnvalues;
     }
