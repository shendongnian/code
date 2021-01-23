        public static string SendFile(string ftpuri, string username, string password, string ftppath, string filename, byte[] datatosend)
        {
            if (ftppath.Substring(ftppath.Length - 1) != "/")
            {
                ftppath += "/";
            }
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpuri + ftppath + filename);
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            ftp.Credentials = new NetworkCredential(username, password);
            ftp.UsePassive = true;
            ftp.ContentLength = datatosend.Length;
            Stream requestStream = ftp.GetRequestStream();
            requestStream.Write(datatosend, 0, datatosend.Length);
            requestStream.Close();
            FtpWebResponse ftpresponse = (FtpWebResponse)ftp.GetResponse();
            return ftpresponse.StatusDescription;
        }
        public static string DeleteFile(string ftpuri, string username, string password, string ftppath, string filename)
        {
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpuri + ftppath + filename);
            ftp.Method = WebRequestMethods.Ftp.DeleteFile;
            ftp.Credentials = new NetworkCredential(username, password);
            ftp.UsePassive = true;
            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }
        public static string MoveFile(string ftpuri, string username, string password, string ftpfrompath, string ftptopath, string filename)
        {
            string retval = string.Empty;
            byte[] filecontents = GetFile(ftpuri, username, password, ftpfrompath, filename);
            retval += SendFile(ftpuri, username, password, ftptopath, filename, filecontents);
            retval += DeleteFile(ftpuri, username, password, ftpfrompath, filename);
            return retval;
        }
