    SampleDataContextDataContext db = new SampleDataContextDataContext();
    Employee emp = new Employee() {
          FirstName = "Experts",
          Lastname = "Comment",
          Address = "rs.emenu@gmail.com"
    };
    
    db.Employees.InsertOnSubmit(emp);
    db.SubmitChanges(); 
    
