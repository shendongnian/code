    using System;
    using System.Xml;
    
    class TestXPath
    {
        static void Main(string[] args)
        {
            string html5Text =
    @"<html>
     <head>
     </head>
     <body>
      <div>
       <ul>
        <li>Line 1</li>
        <li>Line 2</li>
        <li>Line 3</li>
       </ul>
      </div>
     </body>
    </html>";
    
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(html5Text);
    
            string xpathExpr = @"/*/*/div//li//text()";
    
            XmlNodeList selection = doc.SelectNodes(xpathExpr);
    
            foreach (XmlNode node in selection)
            {
                Console.WriteLine(node.OuterXml);
            }
    
        }
    }
