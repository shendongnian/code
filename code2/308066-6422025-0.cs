    protected void btnDoSomething_Click(object sender, EventArgs e)
    {
        Session["Value"] = String.Empty;
        Response.Redirect(strURL, false);
    }
    
