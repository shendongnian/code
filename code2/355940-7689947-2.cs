    if (Page.IsPostBack)
    {
        if (Request.Files.Count > 0)
        {
            AsyncText.Text = "file of correct format";
            ListItem item = new ListItem("item to add");
            lb.Items.Add(item);
        }
    }
