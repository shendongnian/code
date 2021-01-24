     protected void Page_Load(object sender, EventArgs e)
     {
        if (Request.IsAuthenticated)
        {
           Response.Write("welcome");
        }
        else
        {
           Response.Redirect("/login.aspx");
        }
     }
