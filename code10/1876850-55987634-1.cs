    public bool UpdateEmployee(Employee employee)
    {
        var existingEmployee = Context.Emplyoees.FirstOrDefault(s => s.Id == employee.Id);
        if (existingEmployee != null)
        {
            //do the update to the database 
            Context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            Context.Entry(existingEmployee).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
        else return false;
    }
