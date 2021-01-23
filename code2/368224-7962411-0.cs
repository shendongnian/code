    Person person = SessionInstance.Get<Person>(id);
    foreach (Family fam in person.Families)
        if (fam.Name == "Jaun")
            {
            fam.Code = 100;
            }
    SessionInstance.Update(person);
