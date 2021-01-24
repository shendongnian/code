    using System.Linq.Expressions;  
    // Creating a parameter for the expression tree.
    ParameterExpression param = Expression.Parameter(typeof(ReadOnlySpan<byte>));
    // get your type
    // get your ConstructorInfo by calling type.GetConstructor(...)
    // Creating an expression for the constructor call and specifying its parameter.
    var ctorCall = Expression.New(type, ctorinfo, param);
    
    // The following statement first creates an expression tree,
    // then compiles it, and then runs it.
    var delegateCtor = Expression.Lambda<Func<ReadOnlySpan<byte>,object>>(
    ctorCall, new ParameterExpression[] { param }).Compile();
    // call it
    var created = delegateCtor(bytes);
