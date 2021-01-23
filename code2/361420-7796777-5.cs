    ubsmysDataSet ds = new ubsmysDataSet();
    ubsmysDataSet.FormSaveDataDataTable dt = new ubsmysDataSet.FormSaveDataDataTable();
    
    ds.Tables.Add(dt);
    
    ds.EnforceConstraints = false;
    
    ubsmysDataSetTableAdapters.FormSaveDataTableAdapter ta = new ubsmysDataSetTableAdapters.FormSaveDataTableAdapter();
    
    if (isAdmin)
    {
    
    }
    else
    {
        ta.FillByUserId(dt,130559)
    }
    
    ds.EnforceConstraints = true;
