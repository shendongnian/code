    static Dictionary<string, Type> TypeMap = new Dictionary<string, Type> {
        { "int", typeof(Int32) },
        { "double", typeof(double) }
    };
    static Dictionary<string, (ExpressionType opType, Type methodType, string methodName)> OpMap = new Dictionary<string, (ExpressionType, Type, string)> {
        { "sum", (ExpressionType.Add, null, "") },
        { "difference", (ExpressionType.Subtract, null, "") },
        { "multiply", (ExpressionType.Multiply, null, "") },
        { "max", (ExpressionType.Call, typeof(Math), "Max") },
        { "min", (ExpressionType.Call, typeof(Math), "Min") },
    };
    Func<object, object, object> MakeFunction(string op, string dataType) {
        var parmType = TypeMap[dataType];
        var parma = Expression.Parameter(typeof(object), "a");
        var parmb = Expression.Parameter(typeof(object), "b");
        var changeTypeMI = typeof(Convert).GetMethod("ChangeType", new[] { typeof(object), typeof(Type) });
        var exprParmType = Expression.Constant(parmType);
        var lefta = Expression.Convert(Expression.Call(changeTypeMI, parma, exprParmType), parmType);
        var rightb = Expression.Convert(Expression.Call(changeTypeMI, parmb, exprParmType), parmType);
        Expression expr = null;
        var opTuple = OpMap[op];
        switch (opTuple.opType) {
            case ExpressionType.Call:
                var mi = opTuple.methodType.GetMethod(opTuple.methodName, new[] { parmType, parmType });
                expr = Expression.Call(mi, lefta, rightb);
                break;
            default:
                expr = Expression.MakeBinary(opTuple.opType, lefta, rightb);
                break;
        }
        var body = Expression.Convert(expr, typeof(object));
        return Expression.Lambda<Func<object, object, object>>(body, new[] { parma, parmb }).Compile();
    }
