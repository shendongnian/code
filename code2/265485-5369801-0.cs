    Protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender,e); 
        Response.Write("CONTENT:" + Master.IsLoggedIn.ToString());
    }
