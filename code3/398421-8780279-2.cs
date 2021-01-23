    static void Main()
    {
        int[] p = new int[20];
    
        // First 10 numbers
        for (int i = 0; i < 10; i++)
            p[i] = i + 1;
    
        Dolpini(out p);
    
        foreach (int m in p)
            Console.WriteLine(m);
    }
    static void Dolpini(out int[] numbers)
    {
        // Next 10 numbers
        for (int k = 10; k < 20; k++)
            p[k] = p[k-10] + p[k-9];
    }
