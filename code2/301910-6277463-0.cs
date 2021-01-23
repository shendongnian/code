    public static void Main()
    {
        var data = new[] { new { X = 1, Y = 1 }, new { X = 1, Y = 2 },
                           new { X = 2, Y = 1 }, new { X = 2, Y = 2 } };
        foreach (var pair in from p in data orderby p.X, p.Y select p)
        {
            Console.WriteLine("{0},{1}", pair.X, pair.Y);
        }
        Console.WriteLine();
        foreach (var pair in from p in data orderby p.X orderby p.Y select p)
        {
            Console.WriteLine("{0},{1}", pair.X, pair.Y);
        }
    }
