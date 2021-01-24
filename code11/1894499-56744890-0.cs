    var firstJoinQuery = (from company in this.TimesheetsContext.companies
                          join country in this.TimesheetsContext.Countries
                          on company.CountryId equals country.Id
                          where (country == 'USA')
                          select new { CountryId = country.Id }).Distinct().ToList;
    
    var secondJoinQuery = (from country in this.TimesheetsContext.Countries
                          join firstJoinQuery
                          on country.CountryId equals firstJoinQuery.CountryId
                          select new { Country = country }).Distinct().ToList();
       var thirdJoinQuery .....
