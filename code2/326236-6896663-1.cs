    static IEnumerable<IAsync> DownloadAsync(string url)
    {
      WebRequest req = HttpWebRequest.Create(url);
      Async<WebResponse> response = req.GetResponseAsync();
      yield return response;
    
      Stream resp = response.Result.GetResponseStream();
      Async<string> html = resp.ReadToEndAsync().ExecuteAsync<string>();
      yield return html;
     
      Console.WriteLine(html.Result);
    }
