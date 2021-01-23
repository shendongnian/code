    MyDataContext db = new MyDataContext();
    MyDataContext db2 = new MyDataContext();
    Car betsy = db.Cars.First(c => c.Name == "Betsy");
    Car betsy2 = new Car();
    betsy2.Id= betsy.Id;
    db2.Cars.Attach(betsy2);
    /* Could be GetName() or whatever, but allows same */
    betsy2.UpdatedBy = betsy.UpdatedBy;  
    betsy2.OtherField = "TestTestTest";   
    db2.SubmitChanges();
    
