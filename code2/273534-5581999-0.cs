                from a in dc.ContentList
                      where a.ContentID != null
                       select new { ID = a.ContentID, a.PriceClass, }).Union(
                        from b in dc.ContentList
                        where dc.ContentList.FirstOrDefault(a=>a.ContentID == b.ContentID) == null
                        select new { ID = b.ContentID, b.PriceClass, };
