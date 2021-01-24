    // get existing values (if you ever need this)
    var existingWebPages = db.WebsiteWebPages.Select(v => v.WebPage);
    // get your pages
    var webPages = GetWebPages().Where(v => v.WebPage.Contains(".htm"));
    // get distinct WebPage values except existing ones
    var distinctWebPages = webPages.Select(v => v.WebPage).Distinct().Except(existingWebPages);
    // create WebsiteWebPage objects
    var websiteWebPages = distinctWebPages.Select(v =>
        new WebsiteWebPage { WebPage = v, WebsiteId = websiteid});
    // save all at once
    db.WebsiteWebPages.AddRange(websiteWebPages);
    db.SaveChanges();
