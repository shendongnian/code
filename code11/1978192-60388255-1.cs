csharp
IEnumerable<WebsiteWebPage> data = GetWebPages();
foreach (var value in data)
{
    if (value.WebPage.Contains(".htm"))
    {
        WebsiteWebPage pagesinfo = new WebsiteWebPage();
        if (db.WebsiteWebPages.All(c=>c.WebPage != value.WebPage|| c.WebsiteId != websiteid))
        {
            pagesinfo.WebPage = value.WebPage;
            pagesinfo.WebsiteId = websiteid;
            db.WebsiteWebPages.Add(pagesinfo);
        }
     }
}
db.SaveChanges();
