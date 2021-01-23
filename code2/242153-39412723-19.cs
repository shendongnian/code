    static void DeleteFtpDirectory(string url, NetworkCredential credentials)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        List<string> lines = new List<string>();
        using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                lines.Add(listReader.ReadLine());
            }
        }
        foreach (string line in lines)
        {
            string[] tokens =
                line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];
            string fileUrl = url + name;
            if (permissions[0] == 'd')
            {
                DeleteFtpDirectory(fileUrl + "/", credentials);
            }
            else
            {
                FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                deleteRequest.Credentials = credentials;
                deleteRequest.GetResponse();
            }
        }
        FtpWebRequest removeRequest = (FtpWebRequest)WebRequest.Create(url);
        removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
        removeRequest.Credentials = credentials;
        removeRequest.GetResponse();
    }
