    using(var client = new WebClient())
    {
        try
        {
            client.DownloadFile(
                "http://stackoverflow.com/questions/8033619/an-exception-occurred-durning-a-webclient-request-c-sharp-asp-net/8033687#8033687",
                @"j:\MyPath");
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
