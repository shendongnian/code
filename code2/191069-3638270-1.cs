        var jobs  = from p in _dataContext.Jobs
        select new 
          {
           	p.Title,
           	p.IsFullTIme,
           	p.Location,
           	p.Category,
           	p.Url,
           	p.Id,
           	p.Keywords
          }
          
          return Json(job.ToList()
                .OrderBy(p=>p.Keywords.Split(' ').Where(n=>k.Contains(n)).Count()),
                 JsonRequestBehavior.AllowGet);
