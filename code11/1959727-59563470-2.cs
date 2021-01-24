    static void Main(string[] args)
    {
        bool ans;
        bool isValid;
        do
        {
            Console.WriteLine("Yes or No?");
            (ans, isValid) = ParseInput(Console.ReadLine());
            if (!isValid)
            {
                Console.WriteLine("You can only answer with Yes or No");
            }
        }
        while (!isValid);
        Console.WriteLine(ans);
    
        (bool, bool) ParseInput(string input) => 
            char.ToUpper(input.FirstOrDefault()) switch
            {
                'Y' => (true, true),
                'N' => (false, true),
                _ => (default, false)
            };
    }
