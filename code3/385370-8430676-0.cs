    XmlTextReader reader = new XmlTextReader(new StringReader(web.GetFileAsString(<Url to your .webpart file here>)));
    
    SPLimitedWebPartManager wpm = web.GetLimitedWebPartManager(<URL to your page>, Syste.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
    
    WebPart wp = (WebPart) wpm.ImportWebPart(reader, out errMsg);
    wp.Title = "My Title for this webpart";
    
    wpm.AddWebPart(wp, <Name of WebpartZone here, e.g. "Header">, <Zone Index here>);
    wpm.SaveChanges(wp);
