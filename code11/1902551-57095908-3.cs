    var rnd = new Random();
    Console.WriteLine(
        string.Join("\n",
            Enumerable
                .Range(1, 5) // returns an IEnumerable<int> containing 1,2,3,4,5.
                .Select(s =>   // for each int in the IEnumerable
                    string.Join(",",
                    Enumerable
                        .Range(1, 5)
                        .Select(i => rnd.Next(1, 20)) // get a random number.
                        .OrderByDescending(r => r) // order the inner IEnumerable
                )
            )
        )
    );
