    class SomethingLikeADocument
    {
         public int ID {get; set;}
         public string DocName {get; set;}
         public DateTime AccessTime {get; set;}
    }
    var lastTen = 
        (from al in db.AccessLogs
        orderby al.AccessTime desc
        select new SomethingLikeADocument
        {
          ID = al.DocId,
          DocName = al.Document.DocName,
          AccessTime = al.AccessTime
        }).Take(10);
