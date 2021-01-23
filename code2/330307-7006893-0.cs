        public void EvaluateAnExpression()
        {
            //Make the parameter
            var parm = Expression.Parameter(typeof(TestClass),"parm");
            
            //Use your method to build the expression
            var exp = GetFieldValueExpression(parm, "testField");
            
            //Build a lambda for the expression
            var lambda = Expression.Lambda(exp, parm);
            //Compile the lamda and cast the result to a Func<>
            var compiled = (Func<TestClass, string>)lambda.Compile();
            
            //We'll make up some object to test on
            var obj = new TestClass();
            //Get the result (it will be TESTFIELD)
            var result = compiled(obj);
        }
