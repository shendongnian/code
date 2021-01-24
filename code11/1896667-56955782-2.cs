    private static string GetFileWithClientContext(string path, string username, string password, string domain)
    {
        var secureString = new SecureString();
        foreach (var ch in password)
        {
            secureString.AppendChar(ch);
        }
        string tempPath = Path.GetTempFileName().Replace(".tmp", Path.GetExtension(path));
        using (var context = new ClientContext(path))
        {
            context.Credentials = new SharePointOnlineCredentials(username, secureString);
            try
            {
                using (var file = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, new Uri(path).AbsolutePath))
                using (var outFile = System.IO.File.OpenWrite(tempPath))
                {
                    file.Stream.CopyTo(outFile);
                }
            }
            catch (WebException e)
            {
                // Error Handling
            }
        }
        return tempPath;
    }
