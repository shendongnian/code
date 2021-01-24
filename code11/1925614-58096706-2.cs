static object DynamicallyGet(string name, params object[] key) {
    var entityName = Expression.Parameter(typeof(string), "entityName");
    var keyValue = Expression.Parameter(typeof(object[]), "keyValue");
    var db = Expression.Variable(typeof(RainDB), "database");
    IList<Expression> procedures = new List<Expression>();
    procedures.Add(Expression.Assign(db, Expression.New(typeof(RainDB))));
    var entityType = typeof(RainDB).GetProperty(name);
    var callMethod = Expression.Call(Expression.MakeMemberAccess(db, entityType), entityType.PropertyType.GetMethod("Find"), keyValue);
    procedures.Add(callMethod);
    var body = Expression.Block(new[] { db }, procedures);
    var lambda = Expression.Lambda<Func<string, object[], object>>(body, entityName, keyValue).Compile();
    return lambda(name , key);
//Call Function:
DynamicallyGet("UserMaster","MyUser")
