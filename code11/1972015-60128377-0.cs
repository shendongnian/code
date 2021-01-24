    public static async Task tempFunc(string username, string password)
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Before work start : {0}", username + i);
            await Task.Delay(2000);
            Console.WriteLine("After work complete : {0}", username + i);
        }
    }
