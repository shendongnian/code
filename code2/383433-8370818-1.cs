        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Assuming this field is an asp.net textbox and not an HTML input
                UPC_txtBox4.Text = Request.QueryString["upc"];
            }
        }
