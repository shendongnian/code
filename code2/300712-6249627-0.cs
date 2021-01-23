    DataSet dataSet;
        if(bool.Parse(System.Configuration.ConfigurationManager.AppSettings["AllowCaching"]))
        {
            //do caching
            if (Context.Cache["YourDataKey"] == null)
            {
                dataSet = GetDataForDataset();
                object objDataset = (object)dataSet;
                Context.Cache.Insert("YourDataKey", objDataset, null, DateTime.Now.AddSeconds(30),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                dataSet = (DataSet)Context.Cache["YourDataKey"];
            }
        }
        else
        {
            //dont do caching
            dataSet = GetDataForDataset();
        }
