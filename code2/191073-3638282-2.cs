    public JsonResult Find(string q)
    {
        var k = q.Split(' ');
        return Json(_dataContext.Jobs
            // Select all the columns we need, including Keywords
            // (still in SQL-land)
            .Select(p => new { p.Title, p.IsFullTime, p.Location, p.Category,
                               p.Url, p.Id, p.Keywords })
            // Move into C#-land
            .AsEnumerable()
            // Do the sorting here in C#-land
            .OrderBy(p => p.Keywords.Split(' ').Count(n => k.Contains(n)))
            // Finally, remove the Keywords column we no longer need
            .Select(p => new { p.Title, p.IsFullTime, p.Location, p.Category,
                               p.Url, p.Id }),
            JsonRequestBehavior.AllowGet);
     }
