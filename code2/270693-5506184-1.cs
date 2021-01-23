    // Sample input
    var input = "Hello Mr. {select firstname from users where userid=7}";
    string output = input;
    var extractedStatements = Parse(input);
    foreach (var statement in extractedStatements)
    {
        // Execute the SQL statement
        var result = Evaluate(statement);
        // Update the output with the result of the SQL statement
        output = output.Replace("{" + statement + "}", result);
    }
