    var people = new[]
    {
        new { Id = 1, Name = "John" },
        new { Id = 2, Name = "Mark" },
        new { Id = 3, Name = "George" }
    };
    var joined = String.Join(", ", people.Select(p => p.Id + ":" + p.Name).ToArray());
    Regex rx = new Regex(", ", RegexOptions.RightToLeft);
    string result = rx.Replace(joined, " and ", 1); // make 1 replacement only
    Console.WriteLine(result);
