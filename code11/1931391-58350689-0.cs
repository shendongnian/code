    class Program
    {
        static void Main(string[] args)
        {
            double d = 3456;
            long l= Convert.ToInt64(d);
            DateTime dt = new DateTime().AddMilliseconds(l);
            Console.WriteLine(dt);
            DateTime epoch = new DateTime(1970,1,1,0,0,0,0).AddMilliseconds(l);
            Console.WriteLine(epoch);
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine("Datetime");
            
            Console.ReadLine();
        }
        protected long GetDateTimeMS(DateTime dt)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return (long)(dt - epoch).TotalMilliseconds;
        }
    }
