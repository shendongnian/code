            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("URL");
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = networkCredential;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            bytes_total = response.ContentLength; //this is an int member variable stored for later
            Console.WriteLine("Fetch Complete, ContentLength {0}", response.ContentLength);
            response.Close();
            webClient = new MyWebClient();
            webClient.Credentials = networkCredential; ;
            webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(FTPDownloadCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FTPDownloadProgressChanged);
            webClient.DownloadDataAsync(new Uri("URL"));
