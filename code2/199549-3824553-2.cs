    var people = new[]
    {
        new { Id = 1, Name = "John" },
        new { Id = 2, Name = "Mark" },
        new { Id = 3, Name = "George" }
    };
    var joined = String.Join(", ", people.Select(p => p.Id + ":" + p.Name).ToArray());
    string result = Regex.Replace(joined, ", ", " and ", RegexOptions.RightToLeft);
    Console.WriteLine(result);
