    string[] dictionary = ReadDictionary(...);
    var solver = new AnagramSolver(dictionary);
    int minimumLength = 1;
    IEnumerable<string> results = solver.SolveAnagram("AEMNS", minimumLength);
    // Output the results:
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
    // Output example: 
    // "NAMES", "MANES", "MEANS", "AMEN", "MANE", "MEAN", "NAME", "MAN", "MAE", "AM", "NA", "AN", "MA", "A",
