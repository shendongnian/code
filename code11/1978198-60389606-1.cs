    IEnumerable<WebsiteWebPage> data = GetWebPages();
    
    var templist = new List<WebsiteWebPage>();
    foreach (var value in data)
    {
        if (value.WebPage.Contains(".htm"))
        {
            WebsiteWebPage pagesinfo = new WebsiteWebPage();
            pagesinfo.WebPage = value.WebPage;
            pagesinfo.WebsiteId = websiteid;
    
            templist.Add(pagesinfo);
        }
    }
    var distinctList = templist.GroupBy(x => x.WebsiteId).Select(group => group.First()).ToList();
    db.WebsiteWebPages.AddRange(distinctList);
    db.SaveChanges();
