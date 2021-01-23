    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            if (Session["PageIndex"] != null && !string.IsNullOrEmpty(Session["PageIndex"].ToString()))
                GridView1.PageIndex = (int) Session["PageIndex"];
        }
    
    }
    
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e) {
        Session["PageIndex"] = e.NewPageIndex;
    }
          
