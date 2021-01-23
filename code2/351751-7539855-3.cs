    using (DbContext db = DbContext.GetNewDbContext()){
        Employee creator = new Employee("Bob");
        Employer employer = new Employer("employer", creator);
        db.Employees.Add(creator);
        db.SaveChanges();
    }
