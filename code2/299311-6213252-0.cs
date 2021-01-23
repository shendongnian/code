      protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string ip = Request.Params["REMOTE_ADDR"].ToString();
            if (ip == "your-ip")
            {
                // no action
            }
            else
            {
                Response.Redirect("url");  
            }
        }
