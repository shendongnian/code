    foreach(var item in actions) {
    
    var actionMethodInfo = typeof(ExpressionBuilder).GetMethod("GetActionExpression")
                            .MakeGenericMethod(typeof(IContext), type);
    
                        LambdaExpression action = (LambdaExpression)actionMethodInfo.Invoke(null, new object[] {item.MethodName, item.Value });
    
    }
