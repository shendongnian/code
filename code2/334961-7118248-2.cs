     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["culture"] != null)
                    ddlLanguage.SelectedValue = Session["culture"].ToString();
                else
                {
                    ddlLanguage.SelectedValue = "en-US";
                    Session["culture"] = "en-US";
                }
            }
        }
    
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["culture"] = ddlLanguage.SelectedValue;
        }
