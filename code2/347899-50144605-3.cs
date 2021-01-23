    Console.WriteLine("    ".IsEmptyOrAllSpaces());      // true
    Console.WriteLine("".IsEmptyOrAllSpaces());          // true
    Console.WriteLine("  BOO  ".IsEmptyOrAllSpaces());   // false
    string testMe = null;
    Console.WriteLine(testMe.IsEmptyOrAllSpaces());      // false
