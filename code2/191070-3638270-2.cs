     return Json(from p in _dataContext.Jobs     
                 order by p.Keywords.Intersect(k).Count()
                 select new { p.Title, p.IsFullTime, p.Location, 
                              p.Category, p.Url, p.Id },     
            JsonRequestBehavior.AllowGet);            
