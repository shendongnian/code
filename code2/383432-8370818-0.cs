        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Response.Redirect(Request.ApplicationPath + "/Form2.aspx?upc=" + UPC_txtBox2.Text, false);
            }
        }
