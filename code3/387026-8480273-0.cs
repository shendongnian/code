    protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
           {
            OfferID = Context.Request.QueryString["ItemID"];
            LoadOffers();
           }
        }
