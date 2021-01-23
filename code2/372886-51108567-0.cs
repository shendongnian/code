    using System;
    using System.Net;
    
    public static class FtpHelper
    {
        public static bool IsFile(Uri requestUri, NetworkCredential networkCredential)
        {
            return GetFtpFileSize(requestUri, networkCredential) != default(long); //It's a Directory if it has no size
        }
        public static FtpWebRequest GetFtpWebRequest(Uri requestUri, NetworkCredential networkCredential, string method = null)
        {
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUri); //Create FtpWebRequest with given Request Uri.
            ftpWebRequest.Credentials = networkCredential; //Set the Credentials of current FtpWebRequest.
    
            if (!string.IsNullOrEmpty(method))
                ftpWebRequest.Method = method; //Set the Method of FtpWebRequest incase it has a value.
            return ftpWebRequest; //Return the configured FtpWebRequest.
        }
        public static long GetFtpFileSize(Uri requestUri, NetworkCredential networkCredential)
        {
            //Create ftpWebRequest object with given options to get the File Size. 
            var ftpWebRequest = GetFtpWebRequest(requestUri, networkCredential, WebRequestMethods.Ftp.GetFileSize);
    
            try { return ((FtpWebResponse)ftpWebRequest.GetResponse()).ContentLength; } //Incase of success it'll return the File Size.
            catch (Exception) { return default(long); } //Incase of fail it'll return default value to check it later.
        }
    }
