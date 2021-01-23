    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = lblHidSortExp.Text;
        if(sortExpression == e.SortExpression)
            sortExpression += " DESC";
        else
            sortExpression == e.SortExpression;
    
       //not sure if this is exactly how you get your datatable, but you get the idea
       DataView myView = new DataView(BindGridView(Session["useremail"].ToString()).Tables[0]);
       myView.Sort = sortExpression;
       marksGridView.DataSource = myView;
       marksGridView.DataBind();
    
       //save sort state
       lblHidSortExp.Text = sortExpression;
    }
