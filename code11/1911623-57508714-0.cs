    using (var dbContext = new MyDbContext())
    {
         DataEntry entryToAdd = new DataEntry()
         {
              // fill the properties you want, leave the primary key zero (default value)
              Name = ...
              Date = ...
              WorkShedules = ...
         };
         // add the DataEntry to the database and save the changes
         dbContext.Add(entryToAdd);
         dbContext.SaveChanges();
    }
