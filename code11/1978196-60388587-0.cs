       IEnumerable<WebsiteWebPage> data = GetWebPages();
    
                            foreach (var value in data)
                            {
                                if (value.WebPage.Contains(".htm"))
                                {
                                    var a = db.WebsiteWebPages.Where(i => i.WebPage == value.WebPage.ToString()).ToList();
                                    if (a.Count == 0)
                                    {
                                        WebsiteWebPage pagesinfo = new WebsiteWebPage();
                                        pagesinfo.WebPage = value.WebPage;
                                        pagesinfo.WebsiteId = websiteid;
                                        db.WebsiteWebPages.Add(pagesinfo);
                                        db.SaveChanges();
                                    }
                                }
                            }
