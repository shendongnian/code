    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(SetContentAsync));
        Label1.Text = "This is now";
    }
    
    private async Task SetContentAsync() 
    {
        Label2.Text = await GetContentAsync();
    }
