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
**<h1>UPDATE</h1>**
To optimize this (given that your table contains much more data than your current list), override your `equals` in `WebsiteWebPage` class to define your uniqueness criteria then:
csharp
var myWebsiteWebPages = data.select(x=> new WebsiteWebPage { WebPage = x.WebPage, WebsiteId = websiteid}).Distinct();
var duplicates = db.WebsiteWebPages.Where(x=> myWebsiteWebPage.Contains(x));
db.WebsiteWebPages.AddRange(myWebsiteWebPages.Where(x=> !duplicates.Contains(x)));
this is a one database query to retrieve ONLY duplicates and then removing them from the list
