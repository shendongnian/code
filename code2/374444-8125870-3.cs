    protected override void OnPreRender(EventArgs e)
    {
        liAdmin.Visible = this.User.IsInRole("Admin");
        //if visible isn't available, use style["display"] = (this.User.IsInRole("Admin") ? "" : "none";
    }
