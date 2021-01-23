    FtpWebRequest reqSize = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://servername/filepath"));
            reqSize.Credentials = new NetworkCredential("user", "password");
            reqSize.Method = WebRequestMethods.Ftp.GetFileSize;
            reqSize.UseBinary = true;
            
            FtpWebResponse loginresponse = (FtpWebResponse)reqSize.GetResponse();
            FtpWebResponse respSize = (FtpWebResponse)reqSize.GetResponse();
            respSize = (FtpWebResponse)reqSize.GetResponse();
            long size = respSize.ContentLength;
            
            respSize.Close();
