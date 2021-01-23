    using System.Timers;
        class Program
        {
            static void Main(string[] args)
            {
                Timer timer = new Timer();
                timer.Interval = new TimeSpan(0, 15, 0).TotalMilliseconds;
                timer.AutoReset = true;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
            }
        
            static void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                throw new NotImplementedException();
            }
        }
