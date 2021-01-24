    string lambdaStr = "(c1, c2, c3) => c1.Close / c2.Close * c3.Close";
    var options = ScriptOptions.Default.AddReferences(typeof(IOhlcv).Assembly);
    // this will be a delegate type and you will need to turn it into one that fits
    dynamic projection = await CSharpScript.EvaluateAsync<dynamic>(lambdaStr, options);
    // or similar
    System.Console.WriteLine(projection(a, b, c));
