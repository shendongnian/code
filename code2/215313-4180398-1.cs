    var baseQuery = (from p in db.tblProCon
                    join a in db.vwAddresssExpanded
                    on p.IdPrimaryCity equals a.IdPrimaryCity
                    where a.AddressType == (byte) AddressType.PrimaryCity &&
              a.IdAddress == idAddress
              order by p.AgreeCount descending
                    select p);
    
    var pros = baseQuery.Where(x=> x.IsPro).Take(3);
    var cons = baseQuery.Where(x=> !x.IsPro).Take(3);
    
    var results = pros
                   .Union(cons)
                   .OrderByDescending(x => x.IsPro)
                   .ThenByDescending(x => x.AgreeCount)
                   .ToList();
