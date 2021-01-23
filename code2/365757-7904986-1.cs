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
    
        if(elem.NodeType == XmlNodeType.Text){
            string replaceString = elem.Value.Replace("highlighted", "<span class=\"highlighted\">highlighted</span>");
            elem.ParentNode.InnerXml = elem.ParentNode.InnerXml.Replace(elem.Value, replaceString);
        }
        Console.WriteLine(doc.DocumentElement.InnerXml);
      }
    }
