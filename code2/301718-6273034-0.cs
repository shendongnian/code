        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            Response.Write("Hello world");
        }
        protected override void Render(HtmlTextWriter writer)
        {
        }
