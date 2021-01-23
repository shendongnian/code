    protected void gv_DataBound(object sender, EventArgs e)
    {
         btnExpExcel.Visible = GridView1.Rows.Count > 0;
         //The Following is actually better , but less readable
         //We cast the sender to Gridview. The sender is the control
         //initiating the event
         //btnExpExcel.Visible = ((GridView)sender).Rows.Count > 0;
    }
