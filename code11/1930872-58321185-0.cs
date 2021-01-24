    class Program
    {
        static void Main(string[] args)
        {
            reset(false, 228.10803f);
        }
        public static void reset(bool a, float b)
        {
            float totalSeconds = b;
            Thread.Sleep(Convert.ToInt32(b));
            if(a)
            {
                a = false;
            }
            else
            {
                a = true;
            }
            Console.WriteLine("Value should be reset after certain time. Bool value is {0}",a);
            Console.ReadLine();
        }
    }
