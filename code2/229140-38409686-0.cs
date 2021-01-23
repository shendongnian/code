    var tests = new string[] { "City",
                    "FirstName",
                    "DOB",
                    "PATId",
                    "RoomNO"};
    foreach (var test in tests)
        Console.WriteLine("{0} -> {1}", test,
                            String.Join("_", new Regex(@"^(\p{Lu}(?:\p{Lu}*|[\p{Ll}\d]*))*$")
                                .Match(test)
                                .Groups[1]
                                .Captures
                                .Cast<Capture>()
                                .Select(c => c.Value.ToUpper())));
