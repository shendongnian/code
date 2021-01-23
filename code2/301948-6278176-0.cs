    using System;
    using System.IO;
    using System.Xml;
    
    public class Sample {
    
      public static void Main() {
    
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(@"<Objects><!--Comment about node--><othernode/><!--Some more comment--></Objects>");
    	
        XmlNode root = doc.FirstChild;
        if (root.HasChildNodes)
        {
          for (int i=0; i<root.ChildNodes.Count; i++)
          {
    		if( 	root.ChildNodes[i] is XmlComment)
    			Console.WriteLine(root.ChildNodes[i].InnerText);
          }
        }
      }
    }
