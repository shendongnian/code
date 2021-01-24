    public List<Record> GetList(){
         var records = new List<Record>();
    
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
         return records;
    }
