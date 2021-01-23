    var query = year == "2011" ?
                     from c in _context.Wxlogs
                     where c.LogYear == year 
                     && (SqlFunctions.DatePart("Month", c.LogDate2) == m3) 
                     && c.LogTime.Contains("23:59")
                     orderby c.LogDate2
                     let LogDate = c.LogDate2
                     select new { 
                         LogDate, 
                         c.Rain_today 
                     });
    // Second part of conditional
                   : from c in _context.Wxlogs
                     where c.LogYear == year 
                     && c.LogMonth == mm 
                     && c.LogTime.Contains("08:59")
                     orderby c.LogDate2
                     let LogDate = EntityFunctions.AddDays(c.LogDate2, -1)
                     select new { 
                         LogDate, 
                         c.Rain_today 
                     });
