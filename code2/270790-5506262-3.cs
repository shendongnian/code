    var c = new Context();
    var e = c.EmployeeTypes.Single(x => x.Text.Equals("second"));
    var p = new Person { 
                Key = originalKey,       // same key
                FirstName = "NewFirst",  // new first name
                LastName = "NewLast"};   // new last name
    c.People.Attach(p); // Attach person first so that changes are tracked 
    c.Entry(p).Reference(e => e.EmployeeType).Load();               
    p.EmployeeType = e; // Now context should know about the change
    c.Entry(p).State = EntityState.Modified;
    c.SaveChanges();
