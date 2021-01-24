    private static string GetFile(string path, string username, string password, string domain)
    {
        var secureString = new SecureString();
        foreach (var ch in password)
        {
            secureString.AppendChar(ch);
        }
        string tempPath = Path.GetTempFileName().Replace(".tmp", ".xlsm");
        using (WebClient client = new WebClient())
        {
            var credentials = new SharePointOnlineCredentials(username, secureString);
            client.Headers[HttpRequestHeader.Cookie] = credentials.GetAuthenticationCookie(new Uri(path));
            try
            {
                client.DownloadFile(path, tempPath);
            }
            catch (WebException e)
            {
                // Error Handling
            }
        }
        return tempPath;
    }
