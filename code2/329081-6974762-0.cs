    private void SendFile(string inputFile, string outputPath)
    {   
        FtpWebRequest request = (FtpWebRequest) WebRequest.Create
            ("ftp://domain//" + outputPath);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.UseBinary = true;
        request.Credentials = new NetworkCredential("username", "password");
    
        byte[] fileContents = File.ReadAllBytes(inputFile);
        request.ContentLength = fileContents.Length;
       
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }
        // This *may* be necessary in order to validate that everything has happened
        using (WebResponse response = request.GetResponse())
        {
        }
    }
