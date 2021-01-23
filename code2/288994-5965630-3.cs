    [STAThread]
    public static void Main()
    {
        int VB$t_i4$L0 = GetCount();
        for (int index = 1; index <= VB$t_i4$L0; index++)
        {
            Console.WriteLine("For {0}", index);
        }
        Console.ReadKey();
    }
