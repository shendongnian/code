    Expression<Func<Obj, bool>> expr = p => p.fieldname.StartsWith("123");
    var body = expr.Body as MethodCallExpression;   // *.StartsWith()
    var obj = body.Object as MemberExpression;      // p.fieldname
    var param = expr.Parameters.First();            // p
    var newAccess = Expression.PropertyOrField(param, "anotherentity"); // p.anotherentity
    var newObj = obj.Update(newAccess);                 // update obj
    var newBody = body.Update(newObj, body.Arguments);  // update body
    var newExpr = expr.Update(newBody, expr.Parameters);// update expr
