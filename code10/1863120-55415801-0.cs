    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["username"] != null) // Checks if username is available in session
       {
           Response.Redirect("Homepage.aspx");  // If user is logged in than redirect to Homepage.aspx 
       }
    }
