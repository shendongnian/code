    string one = "Caf\u00e9";        // U+00E9 LATIN SMALL LETTER E WITH ACUTE
    string two = "Cafe\u0301";       // U+0301 COMBINING ACUTE ACCENT
    Console.WriteLine(one == two);                                          // False
    Console.WriteLine(one.Equals(two));                                     // False
    Console.WriteLine(one.Equals(two, StringComparison.InvariantCulture));  // True
