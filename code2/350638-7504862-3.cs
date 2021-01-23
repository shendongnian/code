    var client = new WebClient();
    foreach (string s in servers)
    {
        try
        {
            response = client.DownloadString(s + "testcon.php");
            if (response == "OK")
            {
                server = s;
                break;
            }
        }
        catch (WebException wex)
        {
        }
    }
