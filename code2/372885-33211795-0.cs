        static bool IsFile(string ftpPath)
        {
            var request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
        
            request.Credentials = new NetworkCredential("foo", "bar");
            try
            {
                using (var response = (FtpWebResponse)request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    return true;
                }
            }
            catch(WebException ex)
            {
                return false;
            }
        }
