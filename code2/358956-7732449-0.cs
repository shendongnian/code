    public class FuncManipulator<T>
    {
        private Func<T> _method;
        
        public void SetExecutableMethod(Func<T> methodParam)
        {
            _method = methodParam;
        }
        
        //you forgot the "params" keyword
        public T ExecuteMethod(params object[] parameterValues)
        {
            //get the number of parameters _method has;
            var methodCallExpression = _method.Body as MethodCallExpression;
            var arguments = methodCallExpression.Arguments;
    
            var newArguments = new List<Expression>();        
            for (int i = 0; i < arguments.Count(); i++ )
            {
                newArguments.Add(Expression.Constant(parameterValues[i]));
            }
    
            //"Clone" the expression, specifying the new parameters instead of the old.
            var newMethodExpression = Expression.Call(methodCallExpression.Object, 
                                                      methodCallExpression.Method, 
                                                      newArguments)
        
            return newMethodExpression.Compile()();
        }
    
    }
    ...
       
    public void InitAndTest()
    {
        SetExecutableMethod( () => _service.SomeMethod1("param1 placeholder", "param2 placeholder") );
    
        T result1 = ExecuteMethod("Test1", "Test2");
        T result2 = ExecuteMethod("Test3", "Test4");
        T result3 = ExecuteMethod("Test6", "Test5");
    }
