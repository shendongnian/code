    Console.WriteLine(GetCharsFromKeys(Keys.E, false, false));    // prints e
    Console.WriteLine(GetCharsFromKeys(Keys.E, true, false));     // prints E
    // Assuming British keyboard layout:
    Console.WriteLine(GetCharsFromKeys(Keys.E, false, true));     // prints é
    Console.WriteLine(GetCharsFromKeys(Keys.E, true, true));      // prints É
