    var linqYears = from year in contextItem.Children
                    select new
                    {
                        Name = year.Fields["page title"],
                        URI = Sitecore.Links.LinkManager.GetItemUrl(year),
                        Months = from month in year.Children
                                 select new
                                 {
                                     Name = month.Fields["page title"],
                                     URI = Sitecore.Links.LinkManager.GetItemUrl(month),
                                     Articles = from article in month.Children
                                                select new
                                                {
                                                    Name = article.Fields["page title"],
                                                    URI = Sitecore.Links.LinkManager.GetItemUrl(article)
                                                }
                                 }
                    };
