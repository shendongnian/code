            long tics = DateTime.Now.Ticks;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    this.Tics1.Value = tics.ToString();
                    Session["Tics"] = tics;
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                if (Session["Tics"] != null && Request["Tics1"] != null)
                {
                    if (Session["Tics"].ToString().Equals((Request["Tics1"].ToString())))
                    {
                        Response.Write("Postback");
                    }
                    else
                    {
                        Response.Write("Refresh");
                    }
                }
                this.Tics1.Value = tics.ToString();
                Session["Tics"] = tics;        
            }
        }
