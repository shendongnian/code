    static void Main(string[] args)
    {
        int i = 0;
        int x = int.MaxValue - 50;
        int z = 42;
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
        st.Start();
        while (i < x)
        {
            i += z;
        }
        st.Stop();
        Console.WriteLine(st.Elapsed.Milliseconds.ToString());
        Console.ReadLine();
    }
