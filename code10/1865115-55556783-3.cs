    protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["url"] != null)
                {
                    Response.Redirect(Session["url"].ToString());
                }
                //code
             }
