    var temp2 = difference[i];
    var PersonToRemove = db.Permissions.SingleOrDefault(s => s.EmployeeName == temp2 && s.StoreId == Persons.StoreId);
    if (PersonToRemove.EmployeeName != null)
    {
        db.Entry(PersonToRemove).State = EntityState.Deleted; // do this instead
        db.SaveChanges();
    }
