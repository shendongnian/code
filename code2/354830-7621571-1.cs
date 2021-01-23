    foreach (DataRow row in dt.Rows)
    {
        try
        {
            DataTable newtable = new DataTable();
            newtable = dt.Clone(); // Use Clone method to copy the table structure (Schema).
            newtable.ImportRow(row); // Use the ImportRow method to copy from dt table to its clone.
            UserInfo = GetInfo(newtable);
    
        catch (Exception exep)
        {
            //
        }
    }
