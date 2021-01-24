    var persons = appCoreDBContext.PersonRepository.GetAll()
                  .Where(p => p.Active.Equals(true))
                  .Select(pl => new
                  {
                     pl,
                     PersonLocs = pl.PersonLocations.Where(ed => ed.EndDate != null)
                     .Select(o => new
                     {
                         o,
                         office = o.Office
                     }),
                     PersonType = pl.PersonType,
                     PersonCoins = pl.PersonCoins
                     .Where(yr => yr.FinancialYear != null)
                     .Select(yr => new
                     {
                         yr,
                         finYear = yr.FinancialYear
                     })
                     .Where(ee => ee.finYear.StartDate.Year == DateTime.Now.Year)
                  })
                  .AsEnumerable()
                  .Select(x => x.pl);
