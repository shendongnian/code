     System.Net.WebClient wc = new System.Net.WebClient();
    
     System.IO.Stream stream = wc.OpenRead(url);
     System.IO.StreamReader reader = new System.IO.StreamReader(stream);
     string s = reader.ReadToEnd();
    
     HtmlDocument doc = new HtmlDocument();
     doc.LoadHtml(s);
    
