    using System;
    using System.Xml;
    
    public class Program
    {
      public static void Main(string[] args)
      {
        XmlDocument document = new XmlDocument();
    
        document.Load("document.xml");
    
        var tokens = document.GetElementsByTagName("token");
    
        foreach(XmlElement token in tokens)
        {
          Console.WriteLine(token.InnerXml);
        }
      }
    }
