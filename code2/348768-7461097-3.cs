    class Program
    {
        private static Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            string test = "111111111111111a1";
            int value;
            
            watch.Start();
            for(int i=0; i< 1000; i++)
            {
                int.TryParse(test, out value);
            }
            watch.Stop();
            Console.WriteLine("TryParse: "+watch.ElapsedTicks);
            watch.Reset();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                IsDigitsOnly(test);
            }
            watch.Stop();
            Console.WriteLine("IsDigitsOnly: " + watch.ElapsedTicks);
            watch.Reset();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                regex.IsMatch(test);
            }
            watch.Stop();
            Console.WriteLine("Regex: " + watch.ElapsedTicks);
            Console.ReadLine();
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
