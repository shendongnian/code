    var entityNs = "myentities";
    var table = "Model";
    var entityType = Type.GetType($"{entityNs}.{table}");
    var methodInfo = typeof(ApplicationDbContext).GetMethod("Set");
    var generic = methodInfo.MakeGenericMethod(entityType);
    dynamic dbSet = generic.Invoke(myContext, null);
    var list = dbSet.GetList();
