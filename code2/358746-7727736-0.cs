    public bool UpdateOrderToShipped(string order)
    {
        if (order.Length() >= 3 && order.Substring(0,3) == "ORD")
        {
           orderNumber = order;
           string batch = ConfigurationManager.AppSettings["SuccessfulOrderBatch"];
           string statement = "UPDATE SOP10100 SET BACHNUMB = '"+ batch +"' WHERE SOPNUMBE = @SOPNUMBE";
           SqlCommand comm = new SqlCommand(statement, connectionPCI);
           comm.Parameters.Add("SOPNUMBE", orderNumber);
           try
           {
               comm.Connection.Open();
               comm.ExecuteNonQuery();
               comm.Connection.Close();
           }
           catch(Exception e)
           {
               comm.Connection.Close();
               KaplanFTP.errorMsg = "Database error: " + e.Message;
           }
           statement = "SELECT SOPTYPE FROM SOP10100 WHERE SOPNUMBE = @SOPNUMBE";
           comm.CommandText = statement;
           SqlDataAdapter da = new SqlDataAdapter(comm);
           DataTable dt = new DataTable();
           da.Fill(dt);
           soptype = dt.Rows[0]["SOPTYPE"].ToString();
    
    
    
           return true;
       } else
       {
          return false;
       }
     }
