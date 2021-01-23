    using(var context = new MyDataContext())
    {
    object[] parameters =  { param1, param2, param3 };
    return context.Database.SqlQuery<myEntityType>("mySpName {0}, {1}, {2}",
    parameters).ToList();
    }
