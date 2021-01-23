    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using System.Xml.XPath;
    
    public class TransformXML
    {
        //This will transform xml document using xslt and produce result xml document
        //and display it
    
        public static void Main(string[] args)
        {
            try
            {
                XPathDocument myXPathDocument = new XPathDocument(sourceDoc);
                XslTransform myXslTransform = new XslTransform();
                XmlTextWriter writer = new XmlTextWriter(resultDoc, null);
                myXslTransform.Load(xsltDoc);
                myXslTransform.Transform(myXPathDocument, null, writer);
                writer.Close();
                StreamReader stream = new StreamReader (resultDoc);
                Console.Write("**This is result document**\n\n");
                Console.Write(stream.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine ("Exception: {0}", e.ToString());
            }
        }
    }
 
