        int CurrentID
        {
            get
            {
                if (Request.Cookies["CurrentID"] != null)
                {
                    return Request.Cookies["CurrentID"].Value.AsID();
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("CurrentID", "0"));
                    return 0;
                }
            }
            set
            {
                if (Response.Cookies["CurrentID"] != null)
                {
                    Response.Cookies.Remove("CurrentID");
                    Request.Cookies.Remove("CurrentID");
                }
                Response.Cookies.Add(new HttpCookie("CurrentID", value.ToString()));
            }
        }
