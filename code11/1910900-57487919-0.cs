    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement notifyCompleteRequestMessage = doc.Descendants().Where(x => x.Name.LocalName == "NotifyCompleteRequestMessage").FirstOrDefault();
                XNamespace ns = notifyCompleteRequestMessage.GetDefaultNamespace();
                DateTime date = (DateTime)notifyCompleteRequestMessage.Descendants().Where(x => x.Name.LocalName == "DateTime").FirstOrDefault();
            }
        }
    }
