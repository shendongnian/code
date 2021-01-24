    protected void Page_Load(object sender, EventArgs e)
    {
      HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
      HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.jasminedirectory.com/computers/companies/");
      var headingNames = doc.DocumentNode.SelectNodes("//a[@class='featuredBox']").ToList();
      botOutput = headingNames.Select(name => name.InnerText).Aggregate((current, next) => $"{current}</br>{next}") + "</br>";
    }
