    //GetContext<>() is a method that will return the IQueryable provider
    //used to produce MyTable entitiy objects
    //pull all records for the past 5 days
    var results = from t in Repository.GetContext<MyTable>()
                  where t.SomeDate >= DateTime.Today.AddDays(-5)
                  && t.SomeDate <= DateTime.Now
                  select t;
