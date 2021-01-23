    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        bool status = chk.Checked;
        GridDataItem item = (GridDataItem)chk.NamingContainer;
        string keyvalue = item.GetDataKeyValue("ProductName").ToString();
        string connectionString ="";
        if(status)
        {
    
        }
    }
