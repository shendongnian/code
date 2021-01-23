        public static string GetRelativePath(string ftpBasePath, string ftpToPath)
        {
           
            if (!ftpBasePath.StartsWith("/"))
            {
                throw new Exception("Base path is not absolute");
            }
            else
            {
                ftpBasePath =  ftpBasePath.Substring(1);
            }
            if (ftpBasePath.EndsWith("/"))
            {
                ftpBasePath = ftpBasePath.Substring(0, ftpBasePath.Length - 1);
            }
            if (!ftpToPath.StartsWith("/"))
            {
                throw new Exception("Base path is not absolute");
            }
            else
            {
                ftpToPath = ftpToPath.Substring(1);
            }
            if (ftpToPath.EndsWith("/"))
            {
                ftpToPath = ftpToPath.Substring(0, ftpToPath.Length - 1);
            }
            string[] arrBasePath = ftpBasePath.Split("/".ToCharArray());
            string[] arrToPath = ftpToPath.Split("/".ToCharArray());
            int basePathCount = arrBasePath.Count();
            int levelChanged = basePathCount;
            for (int iIndex = 0; iIndex < basePathCount; iIndex++)
            {
                if (arrToPath.Count() > iIndex)
                {
                    if (arrBasePath[iIndex] != arrToPath[iIndex])
                    {
                        levelChanged = iIndex;
                        break;
                    }
                }
            }
            int HowManyBack = basePathCount - levelChanged;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < HowManyBack; i++)
            {
                sb.Append("../");
            }
            for (int i = levelChanged; i < arrToPath.Count(); i++)
            {
                sb.Append(arrToPath[i]);
                sb.Append("/");
            }
            return sb.ToString();
        }
        public static string MoveFile(string ftpuri, string username, string password, string ftpfrompath, string ftptopath, string filename)
        {
            string retval = string.Empty;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpuri + ftpfrompath + filename);
            ftp.Method = WebRequestMethods.Ftp.Rename;
            ftp.Credentials = new NetworkCredential(username, password);
            ftp.UsePassive = true;
            ftp.RenameTo = GetRelativePath(ftpfrompath, ftptopath) + filename;
            Stream requestStream = ftp.GetRequestStream();
          
            FtpWebResponse ftpresponse = (FtpWebResponse)ftp.GetResponse();
            Stream responseStream = ftpresponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }
