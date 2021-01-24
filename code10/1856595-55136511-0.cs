    foreach (DataRow dr in ds.Tables[0].Rows)
    {
        string oldValue = dr.Field<string>("ColumnName");
    
        // check if the column has value
        if (!string.IsNullOrEmpty(oldValue))
        {
            dr.SetField("ColumnName", value.ToString());
        }
        else
        {
            // do something else
        }
    }
    ds.Tables[0].AcceptChanges();
    // rebind the data source here
