    class Program
    {
        static TimeSpan updateInterval = TimeSpan.FromSeconds(5);
        static Thread tWorker;
        static ManualResetEvent tReset;
        static void Main(string[] args)
        {
            tReset = new ManualResetEvent(false);
            tWorker = new Thread(new ThreadStart(PollForUpdates));
            tWorker.Start();
            Console.Title = "Press ENTER to stop";
            Console.ReadLine();
            tReset.Set();
            tWorker.Join();
        }
        static void PollForUpdates()
        {
            SegmentedDownloader segDL = new SegmentedDownloader("http://localhost/dataFile.txt");
            do
            {
                Stream fileData = segDL.GetLatest();
                if (fileData != null)
                {
                    using (StreamReader fileReader = new StreamReader(fileData))
                    {
                        if (fileReader.Peek() > 0)
                        {
                            do
                            {
                                Console.WriteLine(fileReader.ReadLine());
                            }
                            while (!fileReader.EndOfStream);
                        }
                    }
                }
            }
            while (!tReset.WaitOne(updateInterval));
        }
    }
