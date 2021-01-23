    var webRequest = WebRequest.Create("http://www.microsoft.com");
    webRequest.GetReponseAsync().ContinueWith(t =>
    {
      if (t.Exception == null)
      {
        using (var sr = new StreamReader(t.Result.GetResponseStream()))
        {
          string str = sr.ReadToEnd();
        }
      }
      else
        System.Diagnostics.Debug.WriteLine(t.Exception.InnerException.Message);
    });
