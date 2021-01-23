    protected void Page_Load(object sender, EventArgs e)
        {
           string username = HttpContext.Current.User.Identity.Name.ToString();
           if (username == "someusername")
           {
              Response.Redirect("someaspxfile.aspx");
           }
        }
