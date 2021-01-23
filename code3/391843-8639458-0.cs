    DataSet toReturn;
    Hashtable paramHash = new Hashtable();
    int local_er_ID = eR_ID.IsNull ? -1 : _eR_ID.Value;
    paramHash.Add("ER_ID", local_eR_ID.ToString());
    string cacheName = BuildCacheString("ntz_dal_ER_X_Note_SelectAllWER_ID", paramHash);
    toReturn = (DataSet)GetFromCache(cacheName);
    if (toReturn == null)
    {
        // Set up parameters (1 input and 0 output)
        SqlParameter[] arParms = {
                new SqlParameter("@ER_ID", local_eR_ID),
            };
        SqlCacheDependency scd;
        // Execute query.
        toReturn = _dbTransaction != null 
            ? _dbConnection.ExecuteDataset(_dbTransaction, "dbo.[ntz_dal_ER_X_Note_SelectAllWER_ID]", out scd, arParms) 
            : _dbConnection.ExecuteDataset("dbo.[ntz_dal_ER_X_Note_SelectAllWER_ID]", out scd, arParms);
        AddToCache(cacheName, toReturn, scd);
    }
    return toReturn;
