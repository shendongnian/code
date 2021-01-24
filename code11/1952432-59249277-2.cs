    DataContext db = new DataContext();
    Person p = db.People.FirstOrDefault();
    // you would have this posted in, but we are creating it here just for 
    illustration
    var vm = new PersonDobVm
    {
        Id = p.Id, // the Id you want to update
        Dob = new DateTime(2015, 1, 1)  // the new DOB for that row
    };
    vm.MapToModel(p);
    db.SaveChanges();
