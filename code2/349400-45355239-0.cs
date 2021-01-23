    var elements = new[] { "A", "B", "C" };
    foreach (var e in elements.Detailed())
    {
        if (!e.IsLast) {
            Console.WriteLine(e.Value);
        } else {
            Console.WriteLine("Last one: " + e.Value);
        }
    }
