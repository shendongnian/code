        protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["BackgroundColor"] != null)
            {
                ColorSelector.SelectedValue = Request.Cookies["BackgroundColor"].Value;
                BodyTag.Style["background-color"] = ColorSelector.SelectedValue;
            }
        }
    }
