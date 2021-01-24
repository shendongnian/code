    class Program
    {
        static void Main(string[] args)
        {
            int i = 100;
            int min = 50;
            while (i >= min)
            {
                if (i == min) Console.Write(i);
                else Console.Write(i + ",");
                i--;
            }
        }
    }
