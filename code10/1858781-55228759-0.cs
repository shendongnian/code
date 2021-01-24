    public static bool CheckLuhnCCNumber(string digits)
    {
        return digits.All(char.IsDigit) && digits.Reverse()
            .Select(c => c - 48)
            .Select((thisNum, i) => i % 2 == 0
                ? thisNum
                :((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
            ).Sum() % 10 == 0;
    }
    public static void Main()
    {       
        Console.Write("Enter visa number: ");
        string num = Console.ReadLine().Replace(" ", "");
    
        if (num.Length != 16 || !CheckLuhnCCNumber(num))
        {
            Console.Write($"The visa number {num} is not correct!");
        }
        else
        {
            //number length and checksum are OKAY
        }
    
        Console.ReadKey(true);
    }
