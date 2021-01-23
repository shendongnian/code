    var machine = new Machine { MachineModelId = 0, 
                                Owner = "Test", SerialNo = "34242341" };
    var contact = new Contact { ... };
    machine.Contacts.Add(contact);
    _db.AddToMachines(machine);
    _db.SaveChanges();
