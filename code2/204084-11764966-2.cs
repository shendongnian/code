    Employee e = null;
    using (var ctx = new MyModelContainer())
    {
         e = ctx.Employees.SingleOrDefault(emp => emp .....);
    }
    using (var ctx2 = new MyModelContainer())
    {
         e; // This entity instance is disconnected from ctx2
    }
