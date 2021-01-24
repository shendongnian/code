    .Select(pl => new PersonViewModel
    {
        pl.id,
        pl.lastModifiedDate,
        pl.active,
        pl.firstName,
        pl.lastName,
        pl.email,
        pl.personType.Select(pt => new PersonTypeViewModel
        {
           pt.id,
           pt.name
        }),             
        personLocs = pl.PersonLocations.Where(ed => ed.EndDate != null)
            .Select(o => new PersonLocationViewModel
            {
               id = o.OfficeId,
               office = o.Office
            }),
        personCoins = pl.PersonCoins
           .Select(yr => new PersonCoinViewModel
           {
               finYear = yr.FinancialYear
           })
           .Where(ee => ee.finYear.StartDate.Year == DateTime.Now.Year)
     }).AsEnumerable();
