    protected void RadGrid_OnItemCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            if(e.CommandName.Equals("ExpandCollapse"))
            {
                string id = ((GridDataItem)e.Item).GetDataKeyValue("ID").ToString();
                // ... do work on id (i.e. save state, etc.) ...
            }
        } catch(Exception ex)
        {
            // What could possibly go wrong? :)
        }
    }
