    var personData = context.People.Where(x => x.ID == id)
        .Select(x => new 
        {
           Person = x,
           IsLocked = x.Property.Any(p => p.isLocked))
        }).Single();
    if (!personData.isLocked)
    {
       context.People.Remove(personData.Person);
       context.SaveChanges();
    }
