    static ((int name1, int name2) result, bool success) Test()
    {
        return ((1, 1), true);
    }
    static void Main()
    {
        var x = Test();
        if (x.success)
        {
            Console.WriteLine("Your numbers are {0} and {1}", x.result.name1, x.result.name2);
        }
    }
