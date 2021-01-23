    private bool CheckConnection()
    {
        WebClient client = new WebClient();
        try
        {
            using (client.OpenRead("http://www.google.com"))
            {
            }
            return true;
        }
        catch (WebException)
        {
            return false;
        }
    }
