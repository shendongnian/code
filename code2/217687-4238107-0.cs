    using System;
    using System.Xml;
    
    public class Sample {
    
      public static void Main() {
     
        // Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<item><name>wrench</name></item>"); //Your string here
    
        // Save the document to a file and auto-indent the output.
        XmlTextWriter writer = new XmlTextWriter("data.xml",null);
        writer.Formatting = Formatting.Indented;
        doc.Save(writer);
      }
    }
