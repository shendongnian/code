    using System;
    using System.Linq.Expressions;
    static void Main(string[] args)
    {
        Expression<Func<string, int, bool>> firstExpression = (a, b) => a == b.ToString();
    
        Func<string, int, bool> firstLambda = (a, b) => a == b.ToString();
        Expression<Func<string, bool>> secondExpression = s => firstLambda(s, 45); // this expression I need just to see how it is compiled
    
    
        var inputParameter = Expression.Parameter(typeof(string), "s");
    
        var invocation = Expression.Invoke(firstExpression, inputParameter, Expression.Constant(47));
    
        var ourBuildExpression = Expression.Lambda<Func<string, bool> > (invocation, new ParameterExpression[] { inputParameter }).Compile();
        Console.WriteLine(ourBuildExpression("45"));
        Console.WriteLine(ourBuildExpression("47"));
        Console.ReadKey();
    }
