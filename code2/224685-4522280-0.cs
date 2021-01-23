        var currentPerson = _context.People.Where(x => x.Id == person.Id).First();
        currentPerson.VerColm = person.VerColm; // set timestamp value
        var ose = _context.ObjectStateManager.GetObjectStateEntry(currentPerson);
        ose.AcceptChanges();       // pretend object is unchanged
        currentPerson.Name = person.Name; // assign other data properties
        _context.SaveChanges();
