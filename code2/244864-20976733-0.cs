    public static List<string> DirectoryListing(string Path, string ServerAdress, string Login, string Password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ServerAdress + Path);
            request.Credentials = new NetworkCredential(Login, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;            
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            List<string> result = new List<string>();
            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }
            reader.Close();
            response.Close();
            return result;
        }
