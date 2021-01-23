    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int *p = null;
                *p = 5;
            }
        }
    }
