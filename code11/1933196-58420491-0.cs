    using System;
    using System.Xml;
    
    XmlDocument doc = new XmlDocument();
    doc.Load(@"./path/test12321/USRDIR/podcast.xml");
    
    // Select all the titles using XPath
    XmlNodeList list = doc.SelectNodes("//Pair/String");
    
    foreach(XmlNode node in list)
    {
       // Get the contents of each <String> tag
       listBox1.Items.Add(node.InnerText);
    }
