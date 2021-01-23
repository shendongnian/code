    protected void DropDownList_OnDataBound(object sender, EventArgs e)
    {
       DropDownList ddl = sender as DropDownList;
       if(ddl != null)
       {
            // call web service and 
            // populate ddl.Items
       }
    }
