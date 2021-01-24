    protected async void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(GetContentAsync)); 
        var contentTask = GetContentAsync();
        Label1.Text = "This is now";
        Label2.Text = await contentTask;
    }
