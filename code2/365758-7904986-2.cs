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
        string ImpossibleMark = "_*_";
        XmlNode elem = doc.DocumentElement.FirstChild;
        string thewWord ="highlighted";
        if(elem.NodeType == XmlNodeType.Text){
            string OriginalXml = elem.ParentNode.InnerXml;
            while(OriginalXml.Contains(ImpossibleMark)) ImpossibleMark += ImpossibleMark;
            elem.InnerText = elem.InnerText.Replace(thewWord, ImpossibleMark);
            string replaceString = "<span class=\"highlighted\">" + thewWord + "</span>";
            elem.ParentNode.InnerXml = elem.ParentNode.InnerXml.Replace(ImpossibleMark, replaceString);
        }
    
        Console.WriteLine(doc.DocumentElement.InnerXml);
      }
    }
