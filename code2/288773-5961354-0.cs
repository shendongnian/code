     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList DropDownList1 = (DropDownList)GridView1.Rows[0].FindControl("DropDownList1");
        }
    }
