        public static void processEventLogTesting()
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Interval = 10000;
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Start();
        }
    
