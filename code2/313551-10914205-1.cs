    private static Uri GetFaviconUrl(string siteUrl)
    {
        // try looking for a /favicon.ico first
        var url = new Uri(siteUrl);
        var faviconUrl = new Uri(string.Format("{0}://{1}/favicon.ico", url.Scheme, url.Host));
        try
        {
            using (var httpWebResponse = WebRequest.Create(faviconUrl).GetResponse() as HttpWebResponse)
            {
                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    // Log("Found a /favicon.ico file for {0}", url);
                    return faviconUrl;
                }
            }
        }
        catch (WebException)
        {
        }
    
        // otherwise parse the html and look for <link rel='icon' href='' /> using html agility pack
        var htmlDocument = new HtmlWeb().Load(url.ToString());
        var links = htmlDocument.DocumentNode.SelectNodes("//link");
        if (links != null)
        {
            foreach (var linkTag in links)
            {
                var rel = GetAttr(linkTag, "rel");
                if (rel == null)
                    continue;
    
                if (rel.Value.IndexOf("icon", StringComparison.InvariantCultureIgnoreCase) > 0)
                {
                    var href = GetAttr(linkTag, "href");
                    if (href == null)
                        continue;
    
                    Uri absoluteUrl;
                    if (Uri.TryCreate(href.Value, UriKind.Absolute, out absoluteUrl))
                    {
                        // Log("Found an absolute favicon url {0}", absoluteUrl);
                        return absoluteUrl;
                    }
    
                    var expandedUrl = new Uri(string.Format("{0}://{1}{2}", url.Scheme, url.Host, href.Value));
                    //Log("Found a relative favicon url for {0} and expanded it to {1}", url, expandedUrl);
                    return expandedUrl;
                }
            }
        }
    
        // Log("Could not find a favicon for {0}", url);
        return null;
    }
    
    public static HtmlAttribute GetAttr(HtmlNode linkTag, string attr)
    {
        return linkTag.Attributes.FirstOrDefault(x => x.Name.Equals(attr, StringComparison.InvariantCultureIgnoreCase));
    }
