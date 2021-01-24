    string str = "Test. One two three.";
    //               zyxwvutsrqponmlkjihgfedcba      ZYXWVUTSRQPONMLKJIHGFEDCBA
    long bitmask = 0b0000010000010000010001000100000000000100000100000100010001;
    int vowels = 0, consonants = 0;
    foreach (var ch in str)
    {
        if(char.IsLetter(ch))
        {
            int shift = ch - 'A';
            if (((bitmask >> shift) & 1) == 1) vowels++;
            else consonants++;
        }
    }
    Console.WriteLine("Vowels: " + vowels);
    Console.WriteLine("Consonants: " + consonants);
