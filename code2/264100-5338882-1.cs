    if(Request.IsAuthenticated)
    {
        GridView gv = ((GridView)LoginView1.FindControl("GridView1"));
        if(gv != null)
        {
            gv.DataSource = query;
            gv.DataBind();
        }
    
    }
