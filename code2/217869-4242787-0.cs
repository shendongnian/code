     List<CaseType> ct = new List<CaseType>();
        try
        {
       OdbcConnection myConn = new OdbcConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);     
       string sql = "select casename,casecode from casetype";
       myConn.Open();
       OdbcCommand cmd = new OdbcCommand(sql, myConn);
       OdbcDataReader MyReader = cmd.ExecuteReader();
       while(MyReader.ReadNext()){
                       ct.Add(new CaseType(){Name = MyReader.Read("casename").ToString(), Type = Convert.ToInt32(MyReader.Read("casetype"))});
                }
     }
        catch (Exception ex)
        {
            Response.Write(ex.StackTrace);
        }   
