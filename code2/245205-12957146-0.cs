    using(var context = new MyDataContext())
    {
    return context.Database.SqlQuery<myEntityType>("mySpName {0}, {1}, {2}",
    new object[] { param1, param2, param3 }).ToList();
    }
