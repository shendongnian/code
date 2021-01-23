    WebClient webClient = new WebClient(); 
    string webAddress = null; 
    try 
    { 
        webAddress = @"http://localhost/upload_file/"; 
        webClient.Credentials = CredentialCache.DefaultCredentials; 
        WebRequest serverRequest = WebRequest.Create(webAddress); 
        serverRequest.Credentials = CredentialCache.DefaultCredentials;
        WebResponse serverResponse; 
        serverResponse = serverRequest.GetResponse(); 
        serverResponse.Close(); 
        webClient.UploadFile(path, "POST", FilePath); 
        webClient.Dispose(); 
        webClient = null; 
    } 
    catch (Exception error) 
    { 
        MessageBox.Show(error.Message); 
    } 
