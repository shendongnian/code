            if (!IsPostBack)
            {
                if (Session["PageIndex"] != null && !string.IsNullOrEmpty(Session["PageIndex"].ToString()))
                    GridView1.PageIndex = (int)Session["PageIndex"];
            }
        
        }
