    var LinqResult = (from c in _context.MeetingSchedule
                      where c.MeetingDate.Date >= DateTime.Now.Date
                      orderby c.MeetingDate.Date
                      select new { c.Location, c.MeetingDate, c.MeetingTime }).ToArray();
    if (LinqResult.Any())
    {
      //SEND NEXT MEETING DATE BACK VIA VIEWSTATE
    }
