     public IEnumerable<Customer> Find(Criteria criteria)
     {
         IEnumerable<Customer> results = GetInMemoryCustomers();
         //Now filter based on criteria How would you do it
         if(!string.IsNullOrEmpty(criteria.Surname))
         {
             results = results.Where(c => c.Surname == criteria.Surname);
         }
         if (!criteria.StartDate.HasValue &&  !criteria.EndDate.HasValue)
         {
             DateTime start = criteria.StartDate.Value;
             DateTime end = criteria.EndDate.Value;
             results = results.Where(c => c.DateOfBirth != null &&
                                          c.DateOfBirth.Value >= start &&
                                          c.DateOfBirth.Value < end);
         }
         return results;
    }
