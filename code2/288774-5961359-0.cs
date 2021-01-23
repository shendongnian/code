    int index = -1;
    
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
     index = e.Row.Index;
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     DropDownList DropDownList2 = GridView1.Rows[index].FindControl("DropDownList2") as DropDownList;
    }
