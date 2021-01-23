    int srvs = servers.Count();
    int i = 0;
    string response = string.Empty;
    while (i < srvs)
    {
        var client = new WebClient();
        try
        {
            response = client.DownloadString(servers[i] + "testcon.php");
            if (response == "OK")
            {
                server = servers[i];.
                break;
            }
        }
        catch (WebException wex)
        {
        }
        i++;
    }
