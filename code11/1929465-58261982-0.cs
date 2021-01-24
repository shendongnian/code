    List<List<string>> listOfListOfvalues = new List<List<string>>();
    listOfListOfvalues.Add(new List<string>() { "a", "b", "c", "d" });
    listOfListOfvalues.Add(new List<string>() { "A", "B", "C" });
    listOfListOfvalues.Add(new List<string>() { "1", "2", "3", "4", "5" });
    string joined = 
        string.Join(", ", listOfListOfvalues.Select(l => "(" + string.Join(", ", l) + ")"));
    Console.WriteLine(joined);
    // Prints: (a, b, c, d), (A, B, C), (1, 2, 3, 4, 5)
