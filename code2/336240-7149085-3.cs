    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request.AppRelativeCurrentExecutionFilePath;
        foreach (MenuItem item in NavigationMenu.Items)
        {
            item.Selected = item.NavigateUrl.Equals(path, StringComparison.InvariantCultureIgnoreCase);
        }
    }
