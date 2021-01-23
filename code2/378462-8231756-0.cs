    var XPATH_BUILD_DATE="/rss/channel/lastBuildDate";
    private void button1_Click(object sender, EventArgs e){
      var xmlDoc = new XmlDocument();
      var webClient = new WebClient();
      var stream = new MemoryStream(webClient.DownloadData("http://www.mysite.com/news/feed/"));
    xmlDoc.Load(stream);
    XmlElement xmlNode = (XmlElement)xmlDoc.SelectSingleNode(XPATH_BUILD_DATE);
    Console.WriteLine(xmlNode.Name + ": " + xmlNode.InnerText);       
