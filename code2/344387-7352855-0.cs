    DateTime dateFrom = new DateTime(2001, 9, 8);
    DateTime dateTo = new DateTime(2001, 9, 9);
    
    var query = from v in dbcontext.Visits
                where v.visit_Date >= dateFrom && v.visit_Date <= dateTo
                group v by v.visit_Status into vg
                select new
                {
                  Status = EntityFunctions.Concat(EntityFunctions.ToUpper(vg.Key[0]),
                                                  EntityFunctions.SubString(1, EntityFunctions.Length(vg.Key) -1),
                  Visits = vg.Count()
                }
