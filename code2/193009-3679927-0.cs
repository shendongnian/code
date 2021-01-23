    string one = "Caf\u00e9";
    string two = "Cafe\u0301";
    Console.WriteLine(one == two);                                          // False
    Console.WriteLine(one.Equals(two));                                     // False
    Console.WriteLine(one.Equals(two, StringComparison.InvariantCulture));  // True
