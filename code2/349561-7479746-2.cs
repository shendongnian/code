    public static void Main(string[] args)
    {
        int a = 2;
        int b = 3;
        if (a != b)
        {
            throw new Exception("Bleh");
        }
        System.Console.WriteLine("Haha it didn't work");
    }
