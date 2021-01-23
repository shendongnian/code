            public bool IsFtpFileExists(string remoteUri, out long remFileSize)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(BuildServerUri(remoteUri));
                FtpWebResponse response;
    
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.Credentials = new NetworkCredential(Username, Password);
                try
                {
                    response = (FtpWebResponse)request.GetResponse();
                    remFileSize = response.ContentLength;
                    return true;
                }
                catch (WebException we)
                {
                    response = we.Response as FtpWebResponse;
                    if (response != null && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        remFileSize = 0;
                        return false;
                    }
                    throw;
                }
            }
