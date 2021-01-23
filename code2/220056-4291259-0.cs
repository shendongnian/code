    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    {
       try
       {
          SqlParameter[] par = new SqlParameter[7];
          par[0] = new SqlParameter("@itemId",it.itemId);
          par[1] = new SqlParameter("@itemName",it.itemName);
          par[2] = new SqlParameter("@itemDescription", it.itemDescription);
          par[3] = new SqlParameter("@itemImage", it.itemImage);
          par[4] = new SqlParameter("@cityId",it.cityId);
          par[5] = new SqlParameter("@Active", it.itemActive);
          par[6] = new SqlParameter("@Status", 100);
          par[6].Direction = ParameterDirection.Output;
          rowNo = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spAddItem", par);
          int returnStatus = (int)par[6].Value;
      }
