        private static List<Thread> threads = new List<Thread>();
        public static void Start ( )
        {
            for (int i = 0; i < Environment.ProcessorCount * 2; i++)
            {
                var t = new Thread(new ThreadStart(QueueReader));
                threads.Add(t);
                t.Start();
            }
        }
        public static void Stop ( )
        {
            threads.ForEach(t => { t.Abort(); t.Join(TimeSpan.FromSeconds(15)); });
        }
