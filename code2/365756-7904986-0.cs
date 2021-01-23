    using System;
    using System.Xml;
    
    public class Sample {
    
      public static void Main() {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(
        "<p>" +
        "This is a text that will be highlighted." +
        "<br />" +
        "<img />" +
        "</p>");
    
        XmlNode elem = doc.DocumentElement.FirstChild;
    
        elem.ParentNode.InnerXml = elem.ParentNode.InnerXml.Replace("highlighted", "<span class=\"highlighted\">highlighted</span>");
        Console.WriteLine(doc.DocumentElement.InnerXml);
      }
    }
