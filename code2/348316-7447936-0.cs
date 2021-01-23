    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("admin"))
        {
            mnu.Items.Add(new MenuItem
            {
                Text = "Administer web site",
                NavigateUrl = "~/admin.aspx"
            });
        }
    }
