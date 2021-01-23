      class TimerTest
    {
       static int i = 0;
        static void Tick(object sender, EventArgs e)
        {
            
            Console.WriteLine(i);
            i++;
        }
        static void Main()
        {
            // interval = 500ms
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Elapsed += Tick;
            tmr.Start();
            Console.ReadLine();
            tmr.Start();
            Console.ReadLine();
            tmr.Stop();
            Console.ReadLine();
            tmr.Start();
            Console.ReadLine();
            tmr.Dispose(); // This both stops the timer and cleans up.
        }
    }
