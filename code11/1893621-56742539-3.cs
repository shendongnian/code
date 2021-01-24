    public override IEnumerable<T> FindWhere(Expression<Func<T, bool>> testFn) {
        var testBody = (BinaryExpression)testFn.Body;
        var fldTestExpr = testBody.Left;
        if (fldTestExpr.NodeType == ExpressionType.Call)
            fldTestExpr = ((MethodCallExpression)fldTestExpr).Object;
    
        if (fldTestExpr is MemberExpression me) {
            var memberName = me.Member.Name;
            
            var newp = Expression.Parameter(me.Type);
            var newBody = testBody.Replace(me, newp);
            var newLambda = Expression.Lambda(newBody, newp);
    
            var newTestFn = newLambda.Compile();
            var testans = (bool) newTestFn.DynamicInvoke("this Samsung that");
            // using DynamicInvoke is not terrible efficient, but lacking a static
            // type for the property means the compiler must use object
        }
    }
