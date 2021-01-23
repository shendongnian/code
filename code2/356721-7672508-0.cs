    protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var user = HttpContext.Current.User;
                if(user.Identity.IsAuthenticated)
                {
                     Session["memberLoggedIn"] = true;
                     Print();
                }
            }
        }
        public void Print()
        {
                if (Convert.ToBoolean(Session["memberLoggedIn"]) == true)
                {
                    Response.Write("ok");
                }
        }
