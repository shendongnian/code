    static void Main(string[] args)
    {
        Expression<Action> p = () => MyMethod("a", "b");
        var m = p.Body as MethodCallExpression;
        var parameters = m.Method.GetParameters();
        for (int i = 0; i < m.Arguments.Count; i++)
        {
            var arg = m.Arguments[i] as ConstantExpression;
            Console.WriteLine("{0}: {1}", parameters[i].Name, arg.Value);
        }
    }
    static void MyMethod(string arg1, string arg2)
    {
    }
