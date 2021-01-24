    var center2 = dbContext.Centers.Find(2);
    var facility3 = dbContext.Facilities.Find(3);
    // TODO: check if really found
    // connect them:
    center2.Facilities.Add(facility3);
    // add a new facility:
    center.Facilities.Add(new Facility() {...});
    dbContext.SaveChanges();
