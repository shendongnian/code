    using(var context = new MyDataContext())
    {  
    return context.Database.SqlQuery<myEntityType>("mySpName {0}, {1}, {2}",
    param1, param2, param3).ToList();
    }
