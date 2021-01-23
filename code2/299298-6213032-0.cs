     protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (ViewState["sortDirection"] == null)
                        ViewState["sortDirection"] = "asc";
    
                    if (ViewState["sortExpression"] == null)
                        ViewState["sortExpression"] = "your-column-name";
                   // Fill the Grid
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
        }
