    // get your pages
    var webPages = GetWebPages().Where(v => v.WebPage.Contains(".htm"));
    // get distinct WebPage values
    var distinctWebPages = webPages.Select(v => v.WebPage).Distinct();
    // create WebsiteWebPage objects
    var websiteWebPages = distinctWebPages.Select(v =>
        new WebsiteWebPage { WebPage = v, WebsiteId = websiteid});
    // save all at once
    db.WebsiteWebPages.AddRange(websiteWebPages);
    db.SaveChanges();
