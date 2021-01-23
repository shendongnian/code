    var query = from u in uSrc join v in vSrc on u.ID equals v.RelatedUID
      where v.Valid && u.Created < DateTime.UtcNow.AddDays(-365)
      select u; // relatively complicated starting point.
    var q1 = query.Where(u => u.Add); // must also have Add true
    var q2 = query.Where(u => u.Test); // must also have Test true
    var q3 = query.Where(u => u.ID < 50); // must also have ID < 50
