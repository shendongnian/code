    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //get the data key
        int userID = (int)GridView1.DataKeys[e.Row.RowIndex]["UserID"];
    
        //get the nested details view control
        DetailsView dv = (DetailsView)e.Row.FindControl("DetailsView1");
        dv.DataSource = GetUserDetailsTable(userID); //your data source
        dv.DataBind();
    }
