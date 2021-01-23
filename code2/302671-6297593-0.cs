    protected void Page_Load(object sender, EventArgs e)
    { 
       object data;
       lock (Cache)
       {
         string key = "dtMine" + "_" + Session["UserID"].ToString();
         data = Cache[key];
         if (data == null)
         {
           data = GetData();
           Cache[key] = data;
         }
       }
       // At this point we know that the data was loaded and added to the cache
       // in a thread-safe manner.
    }
