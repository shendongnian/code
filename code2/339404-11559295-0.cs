    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        SqlCommand cmd = new SqlCommand("Delete From userTable (userName,age,birthPLace)");
        GridView1.DataBind();
    }
