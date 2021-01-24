    using System.Linq;
    ...
    var stringArray = new string[] { "a b", "a b", "a b" };
    var result = stringArray
        .Select(str => str.Split(' ').Last())
        .ToArray();
    Console.WriteLine("{ " + string.Join(", ", result) + " }");
    // { b, b, b }
