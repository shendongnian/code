    public static void DeleteFTPFile(string Path, string ServerAdress, string Login, string Password)
        {
            FtpWebRequest clsRequest = (System.Net.FtpWebRequest)WebRequest.Create("ftp://" + ServerAdress + Path);
            clsRequest.Credentials = new System.Net.NetworkCredential(Login, Password);
            clsRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            string result = string.Empty;
            FtpWebResponse response = (FtpWebResponse)clsRequest.GetResponse();
            long size = response.ContentLength;
            Stream datastream = response.GetResponseStream();
            StreamReader sr = new StreamReader(datastream);
            result = sr.ReadToEnd();
            sr.Close();
            datastream.Close();
            response.Close();
        }
