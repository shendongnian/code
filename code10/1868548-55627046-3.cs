    facility3.Centers.Add(center2);
    dbContext.Facilities.Add(new Facility()
    {
        ...
        Centers = new Center[] {center2},
    });
