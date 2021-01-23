    using(var client = new WebClient())
    {
        try
        {
            client.DownloadFile(
                "http://stackoverflow.com/users/541404/fake:1",
                @"j:\MyPath\541404.html");
        }
        catch (Exception ex)
        {
            while (ex != null)
            {
                Console.WriteLine(ex.Message);
                ex = ex.InnerException;
            }
        }
    }
