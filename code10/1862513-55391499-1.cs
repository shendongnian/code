    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        if (gvr.RowType == DataControlRowType.DataRow)
        {
            string Namme = (gvr.FindControl("LabelName") as Label).Text;
            //Write Query here to Delete Data
        }
    }
