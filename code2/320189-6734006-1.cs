     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)e.Row.DataItem).Row;
            if (dr["uploadedBy"].ToString() != HttpContext.Current.User.Identity.Name)
            {
                ((Button)e.Row.FindControl("btnDelete")).Visible = false;
            }
         }
     }
