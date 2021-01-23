    private static void Main(string[] args)
    {
        var letters = "0123456789abcdefghijklmnop".ToArray();
        var initial = "0000";
        for (int i = 0; i < 10000; i++)
        {
            initial = Increment(initial, letters);
            Console.WriteLine(initial);
        }
        Console.ReadLine();
    }
    public static string Increment(string input, char[] alphabet)
    {
        var sa = input.ToArray();
        var lastChar = sa[sa.Length - 1];
        if (lastChar != alphabet.Last())
        {
            var index = Array.IndexOf(alphabet, lastChar);
            sa[sa.Length - 1] = alphabet[index + 1];
            return new string(sa);
        }
            
        return Increment(input.Substring(0, input.Length - 1), alphabet) + alphabet[0];
    }
