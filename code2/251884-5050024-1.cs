    /// Returns the content of a given web adress as string.
    /// </summary>
    /// <param name="Url">URL of the webpage</param>
    /// <returns>Website content</returns>
    public string DownloadWebPage(string Url)
    {
      // Open a connection
      HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(Url);
 
      // You can also specify additional header values like 
      // the user agent or the referer:
      WebRequestObject.UserAgent	= ".NET Framework/2.0";
      WebRequestObject.Referer	= "http://www.example.com/";
 
      // Request response:
      WebResponse Response = WebRequestObject.GetResponse();
 
      // Open data stream:
      Stream WebStream = Response.GetResponseStream();
 
      // Create reader object:
      StreamReader Reader = new StreamReader(WebStream);
 
      // Read the entire stream content:
      string PageContent = Reader.ReadToEnd();
 
      // Cleanup
      Reader.Close();
      WebStream.Close();
      Response.Close();
 
      return PageContent;
    }
