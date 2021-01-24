    public void CreateEmployeeForPerson(Person person)
    {
       var employee = new Employee( Title = "Developer", Person = person );
       Context.Employees.Add(employee);
       Context.SaveChanges();
    }
