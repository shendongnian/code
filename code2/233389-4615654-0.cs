    public static string GetWebPageTitle(string url)
    {
       // Create a request to the url
       HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
      
       // If the request wasn't an HTTP request (like a file), ignore it
       if (request == null) return null;
     
       // Use the user's credentials
       request.UseDefaultCredentials = true;
     
       // Obtain a response from the server, if there was an error, return nothing
       HttpWebResponse response = null;
       try { response = request.GetResponse() as HttpWebResponse; }
       catch (WebException) { return null; }
     
       // Regular expression for an HTML title
       string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
     
       // If the correct HTML header exists for HTML text, continue
       if (new List<string>(response.Headers.AllKeys).Contains("Content-Type"))
          if (response.Headers["Content-Type"].StartsWith("text/html"))
          {
             // Download the page
             WebClient web = new WebClient();
             web.UseDefaultCredentials = true;
             string page = web.DownloadString(url);
     
             // Extract the title
             Regex ex = new Regex(regex, RegexOptions.IgnoreCase);
             return ex.Match(page).Value.Trim();
          }
     
       // Not a valid HTML page
       return null;
    }
