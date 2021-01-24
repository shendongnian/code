    public void CreateEmployeeForPerson(int personId)
    {
       var person = Context.Persons.Single(x => x.PersonId == personId);
       var employee = new Employee( Title = "Developer", Person = person );
       Context.Employees.Add(employee);
       Context.SaveChanges();
    }
