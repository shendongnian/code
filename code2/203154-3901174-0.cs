    var person = ctx.Persons.Where(s => s.Id == id).FirstOrDefault();
    string ts = form.Get("person_ts"); // get the persisted value from form
    if (person.TimeStamp != ts)
    {
       throw new Exception("Person has been updated by other user");
    }
    TryUpdateModel(person, form.ToValueProvider());     
    // EF will check the timestamp again if the timestamp column's 
    // ConcurrencyMode is set to fixed.
    ctx.SaveChanges();
