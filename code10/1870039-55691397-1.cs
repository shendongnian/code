    public static bool UploadFile(string url, string userName, string password, string file, out string statusDescription)
    {
        try
        {
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            // Copy the entire contents of the file to the request stream.
            var sourceStream = new StreamReader(file);
            var fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            var getResponse = request.GetResponse();
            Console.WriteLine($"{fileContents.Length} {getResponse} ");
        }
    }
