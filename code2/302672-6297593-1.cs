    protected void Page_Load(object sender, EventArgs e)
    { 
       string key = "dtMine" + "_" + Session["UserID"].ToString();
 
       DataProxy proxy = null;
       
       lock (Cache)
       {
         proxy = Cache[key];
         if (proxy == null)
         {
           proxy = new DataProxy();
           Cache[key] = proxy;
         }
       }
       object data = proxy.GetData();
    }
    private class DataProxy
    {
      private object data = null;
      public object GetData()
      {
        lock (this)
        {
          if (data == null)
          {
            data = LoadData(); // This is what actually loads the data.
          }
          return data;
        }
      }
    }
