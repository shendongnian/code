     foreach(var pair in parcels
        .Where(p => p.Owners != null)
        .SelectMany(p => new { o = p.Owners, p })
        .OrderByDescending(x => x.o.RecordingDate ?? x.o.SaleDate ?? x.o.DateEntered)) {
        var owner = pair.o;
        var parcel = pair.p;
        // do stuff
     }
     // alternate syntax
     foreach(var pair in from p in parcels
                         where p.Owners != null
                         from o in p.Owners
                         orderby o.RecordingDate ?? o.SaleDate ?? o.DateEntered descending
                         select new { o, p }) {
         var owner  = pair.o;
         var parcel = pair.p;
         // do stuff
     }
