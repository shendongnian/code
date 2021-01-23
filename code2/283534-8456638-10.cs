    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack && HttpContext.Items.Contains("CrossPagePostBack") == false)
        {
            // Cross page postback did not succeed (JavaScript disabled)
           if(HttpContext.Items.Contains("Transfer"))
           {
               // We did not yet transfer to Page 2
               HttpContext.Items.Add("Transfer", true);
               Server.Transfer("Page2.aspx");
           }
        }
    }
