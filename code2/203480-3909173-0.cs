    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    using System.IO;
    using System.Xml.XPath;
    using System.Net;
    class Program
    {
        static void Main(string[] args)
        {
            var html = GetHtml(@"http://armory.wow-europe.com/arena-ladder.xml?ts=2&b=Blackout");
            Console.WriteLine(html);
        }
        public static string GetHtml(string url)
        {
            NonRedirectingXmlUrlResolver resolver = new NonRedirectingXmlUrlResolver();
            XmlReaderSettings pagesettings = new XmlReaderSettings();
            pagesettings.XmlResolver = resolver;
            XmlReader page = XmlReader.Create(url, pagesettings);
            XmlDocument doc = new XmlDocument();
            doc.Load(page);
            string xslhref = resolver.ResolveUri(new Uri(url), GetXsltHref(doc)).OriginalString;
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlWriter writer = XmlWriter.Create(sw);
            XslCompiledTransform transform = new XslCompiledTransform();
            page = XmlReader.Create(url, pagesettings);
            transform.Load(xslhref, new XsltSettings(true, true), new XmlUrlResolver());
            transform.Transform(page, null, writer, new NonRedirectingXmlUrlResolver());
            return sb.ToString();
        }
        public static string GetXsltHref(XmlDocument doc)
        {
            XmlProcessingInstruction styleSheet = doc.SelectSingleNode("processing-instruction('xml-stylesheet')") as XmlProcessingInstruction;
            if (styleSheet == null)
                return null;
            XmlDocument pidoc = new XmlDocument();
            pidoc.LoadXml(string.Format("<xsl {0}/>", styleSheet.Data));
            return pidoc.DocumentElement.GetAttribute("href");
        }
    }
    public class NonRedirectingXmlUrlResolver : XmlUrlResolver
    {
        public NonRedirectingXmlUrlResolver() {}
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(absoluteUri);
            httpRequest.UserAgent = @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                return httpResponse.GetResponseStream();
        }
    }
