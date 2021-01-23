     var jsonData = new
                {
                    total = qry.TotalPages,
                    page = page,
                    records = qry.TotalCount,
                    rows = (
                        from n in qry
                        select new
                        {
                            i = n.NewsID,
                            cell = new string[] { n.NewsID.ToString(), n.Headline, n.DateCreated.ToString() }
                        }).ToArray()
                };
    
    return Json(jsonData, JsonRequestBehavior.AllowGet);
