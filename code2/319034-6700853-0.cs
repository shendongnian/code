    public static IQueryable<User> SelectFromEmployee(int employee)
    {
        using (var ctx = Database.AccountingContext())
        {
            return ctx.Users.Where(c => c.Employee_FK == employee).ToList().AsQueryable();
        }
    }
