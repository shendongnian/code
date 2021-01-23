    public void addCompanyToDatabase()
    {
        using (var context = new myTestEntities())
        {
            Company c = new Company();
            c.Name = "xyz";
            context.Companies.AddObject(c);
            Employee e = new Employee();
            e.Age = 15;
            e.Name = "James";
            e.CompanyId = c.Id;
            context.Employees.AddObject(e);
            
			// Only call SaveChanges last.
            context.SaveChanges();
        }
    }
