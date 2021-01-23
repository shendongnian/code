    protected void Page_Load(object sender, EventArgs e)
    {
       if (!this.IsPostBack)
    {
        BindgrdTrades();            
    }
    private void BindgrdTrades()
    {
        DBUtil DB = new DBUtil();
        grdTrades.DataSource = DB.GetTrades();
        grdTrades.DataKeyNames = new string[] { "tradeId" };
        grdTrades.DataBind(); 
    }
    }
    void grdTrades_PageIndexChanging(Object sender, GridViewPageEventArgs e) 
    {
     
        grdTrades.PageIndex = e.NewPageIndex; 
        BindgrdTrades(); 
    } 
    }
