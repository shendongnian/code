    public static void DownloadAndProcessXml(string url, string userAgent, string outputFilePath)
    {
        using (XmlTextWriter writer = new XmlTextWriter(outputFilePath, Encoding.UTF8))
        {
            DownloadAndProcessXml(url, userAgent, writer);
        }
    }
    public static void DownloadAndProcessXml(string url, string userAgent, XmlWriter output)
    {
        UserAgentXmlUrlResolver resolver = new UserAgentXmlUrlResolver(url, userAgent);
        
        // WebClient is an easy to use class.
        using (WebClient client = new WebClient())
        {
            // download Xml doc. set User-Agent header or the site won't answer us...
            client.Headers[HttpRequestHeader.UserAgent] = resolver.UserAgent;
            HtmlDocument xmlDoc = new HtmlDocument();
            xmlDoc.Load(client.OpenRead(url));
            // determine xslt (note the xpath trick as Html Agility Pack does not support xml processing instructions)
            string xsltUrl = xmlDoc.DocumentNode.SelectSingleNode("//*[name()='?xml-stylesheet']").GetAttributeValue("href", null);
            // download Xslt doc
            client.Headers[HttpRequestHeader.UserAgent] = resolver.UserAgent;
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(new XmlTextReader(client.OpenRead(url + xsltUrl)), new XsltSettings(true, false), null);
            // transform Html/Xml doc into new Xml doc, easy as HtmlDocument implements IXPathNavigable
            // note the use of a custom resolver to overcome this Xslt resolve requests
            xslt.Transform(xmlDoc, null, output, resolver);
        }
    }
    // This class is needed during transformation otherwise there are errors.
    // This is probably due to this very specific Xslt file that needs to go back to the root document itself.
    public class UserAgentXmlUrlResolver : XmlUrlResolver
    {
        public UserAgentXmlUrlResolver(string rootUrl, string userAgent)
        {
            RootUrl = rootUrl;
            UserAgent = userAgent;
        }
        public string RootUrl { get; set; }
        public string UserAgent { get; set; }
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            WebClient client = new WebClient();
            if (!string.IsNullOrEmpty(UserAgent))
            {
                client.Headers[HttpRequestHeader.UserAgent] = UserAgent;
            }
            return client.OpenRead(absoluteUri);
        }
        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            if ((relativeUri == "/") && (!string.IsNullOrEmpty(RootUrl)))
                return new Uri(RootUrl);
            return base.ResolveUri(baseUri, relativeUri);
        }
    }
