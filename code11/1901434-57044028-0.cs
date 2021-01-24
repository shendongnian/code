    static private async Task callWebApi()
    {
      WebResponse response = await WebRequest
          .Create("http://**?**.azurewebsites.net/api/sleepy")
          .GetResponseAsync()
          .ConfigureAwait(false);;
      WriteLine(response.StatusCode.ToString());
    }
    public static void Main(string[] args)
    {
      try
      {
        callWebApi().Wait();
      }
      catch (Exception ex)
      {
        WriteLine($"There was an exception: {ex.ToString()}");
      }
    }
