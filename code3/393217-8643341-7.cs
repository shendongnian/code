        return Json(new
        {
            sEcho = param.sEcho,
            iTotalRecords = qry.TotalCount,
            iTotalDisplayRecords = qry.TotalCount,
            aaData = (
                from n in qry
                select new[]
                {
                    Url.Action("Detail", new { newsID = n.NewsID, headline = n.Headline.ToURLParameter() }),
                    Url.Action("Edit", new { newsID = n.NewsID, headline = n.Headline.ToURLParameter() }),
                    Url.Action("Delete", new { newsID = n.NewsID }),
                    n.Headline, 
                    n.DateCreated.ToString() 
                }).ToArray()
        }, JsonRequestBehavior.AllowGet);
