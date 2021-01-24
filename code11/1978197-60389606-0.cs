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
    db.WebsiteWebPages.AddRange(templist.Distinct());
    db.SaveChanges();
