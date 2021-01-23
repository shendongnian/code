    static readonly char[] numbers = "0123456789".ToCharArray();
    static void Main()
    {
        string myString = "USD3,000";
        int i = myString.IndexOfAny(numbers);
        if (i >= 0)
        {
            string s = myString.Substring(i);
            Console.WriteLine(s);
        }
    }
