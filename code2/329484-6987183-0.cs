          protected void Page_Load(object sender, EventArgs e)
        {
    if(!IsPostBack)
         {
            string industry = "";
    
            if (Request.QueryString["ind"] != null)
            {
                industry = Request.QueryString["ind"].ToString();
                if (industry != "")
                {
                    indLabel.Text = "Industry: " + industry;
                    IndustryDropDownList.SelectedValue = industry;
                }
            }
          }
        }
