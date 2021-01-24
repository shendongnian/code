    try
    {
        foreach (Person person in persons)
        {
            person.Status = Status.Finish;
            person.Changed = DateTime.Now;
            person.Role = Role.Worker;
            MyContext.Persons.AddOrUpdate(person);
        }
        var affectedRows = await MyContext.SaveChangesAsync();
        return (int)(persons.Count == affectedRows);
    }
    catch (EntityCommandExecutionException ex)
    {
        return 0;
    }
