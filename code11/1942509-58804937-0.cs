    static void Main(string[] args)
    {
        string textToEncode = File.ReadAllText(@"C:\Users\ASUS\Desktop\szyfrowanie2\TextSample.txt");
        textToEncode = textToEncode.ToLower();
        char[] distinctLetters = textToEncode.Distinct()
                                             .Where(c=> !"\r\n".Contains(c))
                                             .ToArray();
        var count = distinctLetters.Count();
        Console.WriteLine("Letters used in text: \n\n");
        int iteration = 0;
        for (int i = 0; i < count; i++)
        {
            if (distinctLetters[i] == ' ') { Console.Write(" <space> "); }
            else { Console.Write(distinctLetters[i] + " "); }
        }
        Console.WriteLine("\n\nEncoding: \nPlease do not use single non-letter characters for coding (such as ',' or '?'");
        List<string> charsUsedToEncode = new List<string>();
        List<string> charsEncoded = new List<string>();
        while (iteration < count)
        {
            if (distinctLetters[iteration] == ' ') { Console.Write("Swap <space> with "); }
            else { Console.Write("Swap " + distinctLetters[iteration] + " with "); }
            string string1 = Console.ReadLine();
            if (string.IsNullOrEmpty(string1))
            {
                Console.WriteLine("You have to type a character. ");
            }
            else if (string1.Length > 1)
            {
                Console.WriteLine("You entered more than one character. ");
            }
            else
            {
                char SwappingMark = char.Parse(string1);
                if (charsUsedToEncode.Contains(SwappingMark.ToString()))
                {
                    Console.WriteLine("\nThis character has already been used.");
                }
                else
                {
                    charsEncoded.Add(distinctLetters[iteration].ToString());
                    charsUsedToEncode.Add(SwappingMark.ToString());
                    SwappingMark = char.ToUpper(SwappingMark);
                    textToEncode = textToEncode.Replace(distinctLetters[iteration], SwappingMark);
                    iteration++;
                }
            }
        }
        textToEncode = textToEncode.ToLower();
        Console.ReadLine();
    }
