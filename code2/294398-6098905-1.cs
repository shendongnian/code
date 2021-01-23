    WebClient request = new WebClient();
    string url = "ftp://ftp.microsoft.com/developr/fortran/" +"README.TXT";
    request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
    
    try
    {
      byte[] newFileData = request.DownloadData(url);
      string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
      Console.WriteLine(fileString);
    }
    catch (WebException e)
    {
      // Do something such as log error, but this is based on OP's original code
      // so for now we do nothing.
    }
