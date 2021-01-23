    string LoremIpsum()
    {
       string HTML = null;
       WebRequest request = WebRequest.Create("http://lipsum.com/feed/html"); 
       request.Credentials = CredentialCache.DefaultCredentials;
       HttpWebResponse response = (HttpWebResponse)request.GetResponse();
       Stream dataStream = response.GetResponseStream();
       StreamReader reader = new StreamReader(dataStream);
       HTML = reader.ReadToEnd(); //se citeste codul HTMl
    
       //searching for Lorem Ipsum
       HTML = HTML.Remove(0, HTML.IndexOf("<div id=\"lipsum\">")); 
       HTML = HTML.Remove(HTML.IndexOf("</div>"));
       HTML = HTML
            .Replace("<div id=\"lipsum\">", "")
            .Replace("</div>", "")
            .Replace("<p>", "")
            .Replace("</p>", "");
    
       reader.Close();
       dataStream.Close();
       response.Close();
       return HTML; 
    }
