    protected void Page_Load(object sender, EventArgs e)
    {
        string search = Request.QueryString["search"];
        if (!string.IsNullOrEmpty(search))
        {
           PopulateWallPosts(search);
        }
    }
    
    private void PopulateWallPosts(string search)
    {
       //my search query code
    }
