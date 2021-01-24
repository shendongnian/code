    protected void DownloadAll(object sender, EventArgs e)
    {
        GridView1.AllowPaging = false;
        BindData();
    
        // ... your code
    
        GridView1.AllowPaging = true;
        BindData();
    }
