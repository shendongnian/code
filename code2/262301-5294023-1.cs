     protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Option"] != null)
            {
                if (Request.QueryString["Option"] == "1")
                {
                    Response.Write("Option 1");
                }
                else if (Request.QueryString["Option"] == "2")
                {
                    Response.Write("Option 2");
                }
            }
        }
