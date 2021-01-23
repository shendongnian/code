    internal class TestClass
    {
    private void DoSomething(string myArg)
    {
        // returns the name of the argument = "myArg"
        string myArgName = GetArgumentName(() => myArg);
        // check
        System.Diagnostics.Debug.Assert(string.Compare("myArg", myArgName, System.StringComparison.InvariantCulture) == 0, "names do not match");
    }
    private static string GetArgumentName<T>(System.Linq.Expressions.Expression<System.Func<T>> argument)
    {
        string argumentName = null;
        System.Linq.Expressions.MemberExpression body = (System.Linq.Expressions.MemberExpression)argument.Body;
        if (body.Member != null)
        {
            argumentName = body.Member.Name;
        }
        if (argumentName == null)
        {
            // could not retrieve argument name
        }
        return argumentName;
    }
}
