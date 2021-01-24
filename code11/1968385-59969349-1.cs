    using System.Linq;
    ...
    var names = firstName
      .Zip(lastName, (first, last) => new { 
         first,
         last 
       })
      .OrderBy(name => name.first) // by first name ascending
      .ThenBy(name => name.last)   // in case of tie by last name ascending
      .ToArray();
    // Let's have a look:
    Console.Write(string.Join(Environment.NewLine, names
      .Select(name => $"{name.first} {name.last}")));
    // If you insist on splitting names back to 2 lists:
    firstName = names
      .Select(name => name.first)
      .ToList(); 
    lastName = names
      .Select(name => name.last)
      .ToList(); 
