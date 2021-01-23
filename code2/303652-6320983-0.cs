    protected void Page_Load(object sender, EventArgs e)
    {
        string DirectoryName = System.Configuration.ConfigurationManager.AppSettings["UploadDirectory"];
        if (Directory.Exists(DirectoryName))
        {
            String[] Files = Directory.GetFiles(DirectoryName);
            myRepeater.DataSource = Files;
            myRepeater.DataBind();
        }
        
    }
    protected void myRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal FileName = (Literal)e.Item.FindControl("FileName");
            String fullName = (String)e.Item.DataItem;
            FileName.Text = fullName.Substring(fullName.LastIndexOf("\\")+1);
        }
    }
