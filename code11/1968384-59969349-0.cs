    var result = firstName
      .Zip(lastName, (first, last) => new { 
         first,
         last 
       })
      .OrderBy(name => name.first)
      .ThenBy(name => name.last)
      .ToArray();
    // Let's have a look:
    Console.Write(string.Join(Environment.NewLine, result
      .Select(name => $"{name.first} {name.last}")));
    // If you insist on splitting name back to 2 lists:
    List<string> firstName = result
      .Select(name => name.first)
      .ToList(); 
    List<string> lastName = result
      .Select(name => name.last)
      .ToList(); 
