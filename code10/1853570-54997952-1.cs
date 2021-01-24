    private void DoneButton_Clicked(object sender, EventArgs e)
    {
        IdEntry.Text = id;
    
        BlogContentsRestClient<BlogContentItemClass> restClient = new 
        BlogContentsRestClient<BlogContentItemClass>();
        await restClient.GetAsync(id); // Here you call the Get API with the id as parameter
    }
