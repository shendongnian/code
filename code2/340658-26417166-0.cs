        public static bool FileExists(string host, string username, string password, string filename)
        {
            // create FTP request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + host + "/" + filename);
            request.Credentials = new NetworkCredential(username, password);
            // we want to get date stamp - to see if the file exists
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                var lastModified = response.LastModified;
                // if we get the last modified date then the file exists
                return true;
            }
            catch (WebException ex)
            {
                var ftpResponse = (FtpWebResponse)ex.Response;
                // if the status code is 'file unavailable' then the file doesn't exist
                // may be different depending upon FTP server software
                if (ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                // some other error - like maybe internet is down
                throw;
            }
        }
