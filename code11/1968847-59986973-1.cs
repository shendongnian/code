    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Report(Report model)
        {
            var startDate = model.Sdate;
            var endDate = model.Edate;
            var QueryResult = (from pay in _context.PaymentRecords.Include(p=>p.Location).Include(p=>p.WeeklyService)
                               //join a in _context.Locations on pay.LocationId equals a.Id
                               //join c in _context.WeeklyServices on pay.WeeklyServiceId equals c.Id
                               where (pay.DepositDate.Date >= startDate)
                               where (pay.DepositDate.Date <= endDate)
                               group pay by new { pay.LocationId,pay.WeeklyServiceId} into g
                               orderby g.Key.LocationId
                               select new Report
                               {
                                   LocationId= g.Key.LocationId,
                                   Attendance = g.Sum(x => x.Attendance),
                                   Amount = g.Sum(x => x.Amount),
                                   WeeklyServiceId =g.Key.WeeklyServiceId
                                   Location = g.Select(pp => pp.Location).First() // This is what you are missing
                                   WeeklyService  = g.Select(pp => pp.WeeklyService ).First()// Also this
                               });
            return View("Report", QueryResult);
        }
