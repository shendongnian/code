    public void UploadFile(byte[] fileData)
    {
        var client = new WebClient();
        client.UploadDataCompleted += client_UploadDataCompleted;
        client.UploadDataAsync(new Uri("http://myuploadlocation.example.com/"), fileData);
    }
    
    void client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
    
        byte[] response = e.Result;
    }
