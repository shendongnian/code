    protected void Page_Load(object sender, EventArgs e)
    {
      HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
      HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.jasminedirectory.com/computers/companies/");
      var headingNames = doc.DocumentNode.SelectNodes("//a[@class='featuredBox']").ToList();
      foreach (var item in headingNames)
      {
        botOutput.Text += item.InnerText + "</br>";
      }
    }
