    using System.Timers;
    class Program
    {
        static void Main(string[] aszArgs)
        {
            Timer myTimer = new Timer(500);
            myTimer.Elapsed += MyTimer_Elapsed;
            myTimer.Enabled = true;
            //Wait for a key. Or do other work... whatever you want
            Console.ReadKey();
        }
        private static bool cleared = true;
        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (cleared)
                Console.WriteLine("Flash text");
            else
                Console.Clear();
            cleared = !cleared;
        }
    }  
