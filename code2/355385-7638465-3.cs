    private static IResult Parse(string rule, Tester tester, Executor executor)
    {
        // split into test/action
        var tokens = rule.Split(':');
        
        // extract the method/parameter part for each expression
        var test = GetMethodAndParams(tokens[0]);
        var action = GetMethodAndParams(tokens[1]);
        // use reflection to find actual methods
        var testMethod = typeof(Tester).GetMethod(test.Method);
        var actionMethod = typeof(Executor).GetMethod(action.Method);
        // return delegates which will simply invoke these methods
        return new Result
        (
            () => (bool)testMethod.Invoke(tester, new object[] { test.Param }),
            () => actionMethod.Invoke(executor, new object[] { action.Param })
        );
    }
