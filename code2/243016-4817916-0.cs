    var maxQuery = 
     from rh in MailSort
     group rh by rh.BarCode into latest
     select new { BarCode = latest.Key, MaxVersion = latest.Max(l => l.Version) }
    ;
    
    var query = 
     from rh2 in MailSort
     join max in maxQuery on new {rh2.BarCode, Version = rh2.Version } 
      equals new { max.BarCode, Version = max.MaxVersion }
     select new { rh2.BarCode, rh2.Version, rh2.AppCode }
    ;
    
    var barCodes = query.ToList();
