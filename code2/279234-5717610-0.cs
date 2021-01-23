    protected void Page_Load(object sender, EventArgs e)     
    {         
        if (Page.IsPostBack == false)
        {
            string x = Request.QueryString["ProductId"];         
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;         string editQuery = "SELECT CustId, CustName, SicNaic, CustCity, CustAdd, CustState, CustZip, BroName, BroId, BroAdd, BroCity, BroState, BroZip, EntityType, Coverage, CurrentCoverage, PrimEx, Retention, EffectiveDate, Commission, Premium, Comments, ProductId FROM ProductInstance WHERE ProductId =" + x;
        }
    }
