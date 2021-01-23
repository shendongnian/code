    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            // Cross page postback did not succeed (JavaScript disabled)
           if(HttpContext.Items.Contains("transferred"))
           {
               // We did not yet transfer to Page 2
               Server.Transfer("Page2.aspx");
           }
        }
    }
