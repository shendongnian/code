    static void Main(string[] args)
    {
        string str = "Hello world";
        string reverse = "";
        int length = str.Length;
        for (int i = length; i >= 0; i--)
        {
            reverse = reverse + str[i-1]; // here a change
        }
        Console.WriteLine(reverse);
        Console.ReadKey();
    }
