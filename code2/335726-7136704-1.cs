    if (year == "2011")
    {
    ra = (from c in _context.Wxlogs
          where c.LogYear == year && 
                && (SqlFunctions.DatePart("Month", c.LogDate2) == m3) 
                && c.LogTime.Contains("23:59") 
                orderby c.LogDate2
                let LogDate = EntityFunctions.AddDays(c.LogDate2, year == "2011" ? 0 : -1)
                select new { 
                            LogDate, 
                            c.Rain_today 
                            }).AsQueryable();
    }
    else if (year != "2011")
    {
    ra = (from c in _context.Wxlogs
          where c.LogYear == year && 
                && c.LogMonth == mm 
                && c.LogTime.Contains("08:59")
                orderby c.LogDate2
                let LogDate = EntityFunctions.AddDays(c.LogDate2, year == "2011" ? 0 : -1)
                select new { 
                            LogDate, 
                            c.Rain_today 
                            }).AsQueryable();
    }
