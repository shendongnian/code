    private static void Main()
    {
        const string AllowedChars =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        Random rng = new Random();
        foreach (var randomString in RandomStrings(AllowedChars, 1, 16, 25, rng))
        {
            Console.WriteLine(randomString);
        }
        Console.ReadLine();
    }
    private static IEnumerable<string> RandomStrings(
        string allowedChars,
        int minLength,
        int maxLength,
        int count,
        Random rng)
    {
        char[] chars = new char[maxLength];
        int setLength = allowedChars.Length;
        while (count-- > 0)
        {
            int length = rng.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; ++i)
            {
                chars[i] = allowedChars[rng.Next(setLength)];
            }
            yield return new string(chars, 0, length);
        }
    }
