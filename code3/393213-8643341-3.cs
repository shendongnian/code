    public JsonResult NewsJSON(jQueryDataTableParamModel param)
        {
            var news = _newsRepository.GetNews();
    
            string col = param.sColumns.Split(',')[param.iSortCol_0];
            string orderby = col + " " + param.sSortDir_0;
    
            if (param.sSearch != null)
                news = news.Search(param.sSearch);
    
            var qry = new PaginatedList<News>(news.OrderBy(orderby), param.iDisplayStart, param.iDisplayLength);
    
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qry.TotalCount,
                iTotalDisplayRecords = qry.TotalCount,
                aaData = (
                    from n in qry
                    select new[]
                    {
                        n.Headline, 
                        n.DateCreated.ToString() 
                    }).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
