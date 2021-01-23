    CodeVariableDeclarationStatement variableDeclaration = new CodeVariableDeclarationStatement(
        // Type of the variable to declare.
        typeof(System.Text.StringBuilder),
        // Name of the variable to declare.
        "TestString",
        // A CodeExpression that indicates the initialization expression for the variable.
        new CodeObjectCreateExpression( typeof(System.Text.StringBuilder), new CodeExpression[] {} )
    );
