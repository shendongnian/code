    {
      using (WebClient client = new WebClient ())
      {
        try
        {
          client.DownloadFile (
            "https://code.org/images/social-media/code-2018-creativity.png",
            @"j:\storage\emulated\legacy\Download\code-2018-creativity.png");
        }
        catch (Exception ex)
        {
          while (ex != null)
          {
            Console.WriteLine (ex.Message);
            ex = ex.InnerException;
          }
        }
      }
    }
