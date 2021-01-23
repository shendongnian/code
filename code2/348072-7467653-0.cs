    // Define the context of our expression
    ExpressionContext context = new ExpressionContext();
    // Allow the expression to use all static public methods of System.Math
    context.Imports.AddType(typeof(Math));
    // Define an int variable
    context.Variables["a"] = 100;
    // Create a dynamic expression that evaluates to an Object
    IDynamicExpression eDynamic = context.CompileDynamic("sqrt(a) + pi");
    // Evaluate the expressions
    double result = (double)eDynamic.Evaluate();
