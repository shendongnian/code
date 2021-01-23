        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["productID"] != null)
                {
                    productID = Convert.ToInt32(Request.QueryString["productID"]);
                    ...
                }
                ...
            }
         }
