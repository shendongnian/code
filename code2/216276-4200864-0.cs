    ...
    [WebMethod]
    public DataSet GetData(object id, string sessionId)
    {
       try
       {
          DataSet ds = null;
          CUser user = Global.GetSession(sessionId);
          
          lock
          {
             //Your code to get data from the database
          }
          return ds;
       }
       catch(Exception ex)
       {
           throw;
       }
    }
