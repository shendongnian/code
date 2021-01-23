      protected void Page_Load(object sender, EventArgs e)
      {
             
                XmlDocument document = new XmlDocument();
               
                string xmlStr;
                using (var wc = new WebClient())
                {
                    xmlStr = wc.DownloadString("test.xml");
                }
    
                var xmlDoc = new XmlDocument();
    
                xmlDoc.LoadXml(xmlStr);
    
                XmlNode xnod = xmlDoc.DocumentElement;
           
               AddWithChildren(xnod, 1);
     }
    
    
           
