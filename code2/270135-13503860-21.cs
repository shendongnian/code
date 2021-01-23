    static void Main(string[] args)
    {
        var ax = new[] { 
            new { id = 1, name = "John" },
            new { id = 2, name = "Sue" } };
        var bx = new[] { 
            new { id = 1, surname = "Doe" },
            new { id = 3, surname = "Smith" } };
        ax.FullOuterJoin(bx, a => a.id, b => b.id, (a, b, id) => new {a, b})
            .ToList().ForEach(Console.WriteLine);
    }
