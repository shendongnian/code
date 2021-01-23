    try to hide controls at DataBound or RowDataBound event of GridView
    
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
            ImageButton edit = (ImageButton)EmployeeDetails.Row.Cells[0].FindControl("Image");
            edit.Visible = false;  
            edit.Enabled = false; //OR use this line 
    }
