            string destination = "ftp://something.com/";
            string file = "test.jpg";
            string extention = Path.GetExtension(file);
            string fileName = file.Remove(file.Length - extention.Length);
            string fileNameCopy = fileName;
            int attempt = 1;
            while (!CheckFileExists(GetRequest(destination + "//" + fileNameCopy + extention)))
            {
                fileNameCopy = fileName + " (" + attempt.ToString() + ")";
                attempt++;
            }
            // do your upload, we've got a name that's OK
        }
        private static FtpWebRequest GetRequest(string uriString)
        {
            var request = (FtpWebRequest)WebRequest.Create(uriString);
            request.Credentials = new NetworkCredential("", "");
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            return request;
        }
        private static bool CheckFileExists(FtpWebRequest request)
        {
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }
