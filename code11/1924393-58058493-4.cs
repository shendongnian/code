    protected void Page_Load(object sender, EventArgs e) {
         if ((string)Session[IsAuthenticated] == "Y")
         {
             Session["GoToFinal"] = "";
             Response.Write("welcome");
         }
         else
         {
             Response.Redirect("login.aspx");
         } 
    }
