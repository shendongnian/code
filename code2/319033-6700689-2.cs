    ObjectContext context = Database.AccountingContext();
    public static IQueryable<User> SelectFromEmployee(int employee)
    {
        return context.Users.Where(c => c.Employee_FK == employee);
    }
