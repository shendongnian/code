    var client = new WebClient();
    foreach (string s in servers)
    {
        try
        {
            response = client.DownloadString(s + "testcon.php");
        }
        catch (WebException wex)
        {
        }
        finally
        {
            if (response == "OK")
            {
                server = s;
                break;
            }
        }
    }
