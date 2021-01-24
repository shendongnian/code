    public async void Test()
    {
        var request = service.Files.Export("YourFileId", "text/plain");
        string result = await request.ExecuteAsync();
        MessageBox.Show(result);
    }
    
