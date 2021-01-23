    CodeEntryPointMethod start = new CodeEntryPointMethod();
    //...
    start.Statements.Add(new CodeVariableDeclarationStatement(typeof(bool), "ifCheck", new CodePrimitiveExpression(false)));
    var e1 = new CodeBinaryOperatorExpression(new CodePrimitiveExpression(false), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(false));
    var e2 = new CodeBinaryOperatorExpression(new CodePrimitiveExpression(false), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(true));
    var ifAssign = new CodeAssignStatement(new CodeVariableReferenceExpression("ifCheck"), new CodeBinaryOperatorExpression(e1, CodeBinaryOperatorType.BooleanOr, e2));
    start.Statements.Add(ifAssign);
    var x1 = new CodeVariableDeclarationStatement(typeof(string), "x1", new CodePrimitiveExpression("Anything here..."));
    var ifCheck = new CodeConditionStatement(new CodeVariableReferenceExpression("ifCheck"), new CodeStatement[] { x1 }, new CodeStatement[] { x1 });
    start.Statements.Add(ifCheck);
