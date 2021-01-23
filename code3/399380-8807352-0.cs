        static Timer timer;
        static int waitTime = 200; //in ms
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\temp\";
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.EnableRaisingEvents = true;
            Console.ReadLine();
        }
        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            DateTime currTime = DateTime.Now;
            if (timer == null)
            {
                Console.WriteLine("Started @ " + currTime);
                timer = new Timer();
                timer.Interval = waitTime;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
            else
            {
                Console.WriteLine("Ignored @ " + currTime);
            }
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Start task here
            Console.WriteLine("Elapsed @ " + DateTime.Now);
            timer = null;
        }
