    protected void Page_Load(object sender, EventArgs e)
    {
                HtmlGenericControl somejs = new HtmlGenericControl("script");
                somejs.Attributes.Add("type", "text/javascript");
                somejs.Attributes.Add("src", ResolveClientUrl("~/Content/js/something.js"));
                this.Page.Header.Controls.Add(somejs);
    }
