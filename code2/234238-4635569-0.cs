    using System;
    using System.IO;
    using System.Xml;
    
    public class Sample {
    
      public static void Main() {
    
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(
    @"<SD>
    <POPULARITY URL="google.com/" TEXT="1"/>
    <REACH RANK="1"/>
    <RANK DELTA="+0"/>
    </SD>
    ");
    
        XmlNode root = doc.FirstChild;
    
        Console.WriteLine(root["popularity"].Attributes["Text"]);
      }
    }
