    using(YourDBContext db = new YourDBContext())
    {
        records = db.records
         .Select(s=> new Record()
         {
           Id = s.Id,
           PrevId = s.PreviousId,
           Desc = s.Description,
         }).ToList();
    }
