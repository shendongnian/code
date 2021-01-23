    Response.Clear();
    Response.ContentType = "text/xml";
    Response.ContentEncoding = System.Text.Encoding.UTF8;
    GoogleNewsSiteMap googleNewsSiteMap = new GoogleNewsSiteMap();
    googleNewsSiteMap.Create(/*put ur data*/);
    Response.Write(googleNewsSiteMap.GetXMLString());
