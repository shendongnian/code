    public static Stack palindrome;
    public static Stack palindromeReverse;
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the string:");
        var text = Console.ReadLine();
        BuildWordStack(text);
        PalindromeCheck(text, ReverseWord());
        Console.ReadKey();
    }
    public static void BuildWordStack(string word)
    {
        palindrome = new Stack();
        for (int i = 0; i < word.Count(); i++)
        {
            palindrome.Push(word.ElementAt(i));
        }
    }
    public static string ReverseWord()
    {
        palindromeReverse = new Stack();
        int n = palindrome.Count;
        for (int i = 0; i < n; i++)
        {
            palindromeReverse.Push(palindrome.Pop());
        }
        string result = "";
        for (int i = 0; i < n; i++)
        {
            result = palindromeReverse.Pop() + result;
        }
        return result;
    }
    public static void PalindromeCheck(string word, string reverse)
    {
        if (word.Replace(" ", "").ToUpper() == reverse.Replace(" ", "").ToUpper())
        {
            Console.WriteLine("It's a palindrome");
        }
        else
        {
            Console.WriteLine("It's not a palindrome");
        }
    }
