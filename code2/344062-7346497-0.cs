    string comparison= "";
    string compare1= "";
    string compare2 = "";
	
    if ( searchExpression.Body is BinaryExpression ) // Ensure the expression is a comparison..
    {
        if ( searchExpression.Body.NodyType == ExpressionType.LessThan )
            comparison = "SENTBEFORE";
        else if ( searchExpression.Body.NodyType == ExpressionType.GreaterThan )
            comparison = "SENTAFTER";
        else  if ( searchExpression.Body.NodyType == ExpressionType.Equal )
            comparison = "EQUALS";
        // Then evaluate the left and right portions.
        if ( ( searchExpression.Body as BinaryExpression ).Left is MemberExpression )
             compare1 = ( ( searchExpression.Body as BinaryExpression ).Left as MemberExpression).Member.Name;
        if ( ( searchExpression.Body as BinaryExpression ).Right is MemberExpression )
             compare2 = ( ( searchExpression.Body as BinaryExpression ).Right as MemberExpression).Member.Name;
    }
    Console.WriteLine ( compare1 + " " + comparison + " " + compare2 );
