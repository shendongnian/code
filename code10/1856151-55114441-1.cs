    public static void Main(string[] args)
    {
        int[] a = { 4, 2, 8, 3, 1 };
        int x = 0;
        x = Convert.ToInt32(Console.ReadLine());
        var b = ShiftLeft(a, x);
        for (int m = 0; m < b.Length; m++)
        {
            Console.Write("{0}, ", b[m]);
        }
        Console.ReadKey();
    }
