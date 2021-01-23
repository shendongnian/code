     // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
                request.Method = WebRequestMethods.Ftp.DownloadFile;
    
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
    
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());
    
                Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
        
                reader.Close();
                response.Close();  
