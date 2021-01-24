            protected void Page_Load(object sender, EventArgs e)
            {
                if (Convert.ToBoolean(uiRemoved.Value))
                {
                    this.Visible = false;
                }
    
                if (!IsPostBack)
                {
                    this.uiDistance.Text = "123"; // it will assign only once when page loads.
                }
            }
