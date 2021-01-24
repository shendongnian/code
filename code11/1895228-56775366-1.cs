    var resultTuple = ValidateWord("Why llll ddd ssssssss".Split(' ').ToArray());
    if (resultTuple.Item1)
    {
        Console.WriteLine($"The following words have 3 similar charecters: " + resultTuple.Item2);
    }
    else
    {
        Console.WriteLine("No words has consecutive 3 similar charecters.");
    }
