    Employee e = null;
    using (var ctx = new MyModelContainer())
    {
         e = ctx.Employees.SingleOrDefault(emp => emp .....);
    }
    using (var ctx = new MyModelContainer())
    {
         e; // This entity instance is disconnected
    }
