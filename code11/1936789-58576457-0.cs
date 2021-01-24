    var input = "the boy sold his car to buy a ball";
    var oldvalues = new List<string>() { "boy", "car", "ball" };
    var newValues = new List<string>() { "dog", "bar", "bone" };
    var output = input;
    for (int i = 0; i < oldvalues.Count; i++)
    {
        output = output.Replace(oldvalues[i], newValues[i]);
    }
    Console.WriteLine(output);
