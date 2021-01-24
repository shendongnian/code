    public static void Third(int x)
    {
        Console.WriteLine("Third invoked");
        int result;
        result = 3 + x;
        Console.WriteLine(result);
    }
    Action a2 = () => Third(50);
