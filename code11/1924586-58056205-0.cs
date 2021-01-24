    try
    {
        using(WebClient client = new WebClient())
       {
        string myFile = @"C:/Users/AR485UY/Desktop/Test1.pdf";
        client.Credentials = CredentialCache.DefaultCredentials;
        client.UploadFile(url, "POST", myFile);
        
        }
    }
    catch (Exception err)
    {
        MessageBox.Show(err.Message);
    }
