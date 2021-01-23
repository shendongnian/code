    foreach (DataRow row in dt.Rows)
    {
        try
        {
            DataTable newtable = new DataTable();
            newtable = dt.Clone();
            newtable.ImportRow(row);
            UserInfo = GetInfo(newtable);
    
        catch (Exception exep)
        {
            //
        }
    }
