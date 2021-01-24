    protected void lb_Click(object sender, EventArgs e)
    {
        string time = (sender as LinkButton).Text;
        Session["TimeSelected"] = time;
        Response.Redirect("/nextstep.aspx");
    }
