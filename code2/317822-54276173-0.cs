    protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) {
                string targetId = Page.Request.Params.Get("__EVENTTARGET");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "focusthis", "document.getElementById('" + targetId + "').focus()", true);
            }
        }
