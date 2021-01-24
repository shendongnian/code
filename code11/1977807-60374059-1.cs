     using(YourDBContext db = new YourDBContext())
     {
        records = db.records
         .Where(m=>m.Id >= 3)
         .Select(s=> new Record()
         {
           Id = s.Id,
           PrevId = s.PreviousId,
           Desc = s.Description,
         }).ToList();
     }
