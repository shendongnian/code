    namespace TestXml
    {
        using System;
        using System.Data;
        using System.IO;
        using System.Xml;
        using System.Xml.XPath;
        using System.Xml.Xsl;
    
        class Program
        {
            static void Main(string[] args)
            {
                CustomObj co = new CustomObj();
                XPathNodeIterator xpni = co.GetResultTable();
    
                XslCompiledTransform xslt = new XslCompiledTransform(true);
                xslt.Load(@"..\..\My.xslt");
                
                XsltArgumentList xargs = new XsltArgumentList();
                xargs.AddExtensionObject("my:extension", co);
    
                XmlDocument fakeDoc = new XmlDocument();
                fakeDoc.LoadXml("<t/>");
    
                StringWriter sw = new StringWriter();
    
                xslt.Transform(fakeDoc.CreateNavigator(), xargs, sw);
    
                string result = sw.ToString();
    
                Console.Write(result);
            }
        }
    
        public class CustomObj
        {    //function that gets called from XSLT    
            public XPathNodeIterator GetResultTable()    
            {        
                DataTable table = new DataTable("Table1");        
                table.Columns.Add("SourceCity");        
                table.Columns.Add("DestinationCity");        
                table.Columns.Add("Fare");        
                table.Rows.Add(new object[] { "New York", "Las Vegas", "100" });        
                table.Rows.Add(new object[] { "New York", "London", "200" });        
                table.Rows.Add(new object[] { "New York", "New Delhi", "250" });        
                StringWriter writer = new StringWriter();        
                table.WriteXml(writer);        
                XmlDocument doc = new XmlDocument();        
                XmlElement root = doc.CreateElement("Root");        
                root.InnerXml = writer.ToString();        
                doc.AppendChild(root);        
                return doc.CreateNavigator().Select("Root");    
            }
        }
    }
