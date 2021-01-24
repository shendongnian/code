    public static bool TestConnection(string IPAdd, string port, string username, string password)
        {
            try
            {
                var downloadRequest = (FtpWebRequest)WebRequest.Create(@"ftp://" + IPAdd + ":" + port);
                downloadRequest.Credentials = new NetworkCredential(username, password);
                downloadRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                var ftpWebResponse = (FtpWebResponse)downloadRequest.GetResponse();
                ftpWebResponse.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
