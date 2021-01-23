     WebClient client = new WebClient();
     string path = Request.Url.GetLeftPart(UriPartial.Authority) + 
                  VirtualPathUtility.ToAbsolute("~/feed.htm");
     Stream stream = client.OpenRead(path);
     StreamReader sr = new StreamReader(stream);
     string content = sr.ReadToEnd();
        
