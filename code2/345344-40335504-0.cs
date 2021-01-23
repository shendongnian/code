    public static class MultiThreadSumRainFall
    {
        const int LongitudeSize = 64;
        const int LattitudeSize = 64;
        const int RainFallSamplesSize = 64;
        const int SampleMinValue = 0;
        const int SampleMaxValue = 1000;
        const int ThreadCount = 4;
        public static void SumRainfallAndOutputValues()
        {
            int[][][] SampleData;
            SampleData = GenerateSampleRainfallData();
            for (int Longitude = 0; Longitude < LongitudeSize; Longitude++)
            {
                for (int Lattitude = 0; Lattitude < LattitudeSize; Lattitude++)
                {
                    QueueWork(new WorkItem(Longitude, Lattitude, SampleData[Longitude][Lattitude]));
                }
            }
            System.Threading.ThreadStart WorkThreadStart;
            System.Threading.Thread WorkThread;
            List<System.Threading.Thread> RunningThreads;
            WorkThreadStart = new System.Threading.ThreadStart(ParallelSum);
            int NumThreads;
            NumThreads = ThreadCount;
            if (ThreadCount < 1)
            {
                NumThreads = 1;
            }
            else if (NumThreads > (Environment.ProcessorCount + 1))
            {
                NumThreads = Environment.ProcessorCount + 1;
            }
            OutputData = new int[LongitudeSize, LattitudeSize];
            RunningThreads = new List<System.Threading.Thread>();
            for (int I = 0; I < NumThreads; I++)
            {
                WorkThread = new System.Threading.Thread(WorkThreadStart);
                WorkThread.Start();
                RunningThreads.Add(WorkThread);
            }
            bool AllThreadsComplete;
            AllThreadsComplete = false;
            while (!AllThreadsComplete)
            {
                System.Threading.Thread.Sleep(100);
                AllThreadsComplete = true;
                foreach (System.Threading.Thread WorkerThread in RunningThreads)
                {
                    if (WorkerThread.IsAlive)
                    {
                        AllThreadsComplete = false;
                    }
                }
            }
            for (int Longitude = 0; Longitude < LongitudeSize; Longitude++)
            {
                for (int Lattitude = 0; Lattitude < LattitudeSize; Lattitude++)
                {
                    Console.Write(string.Concat(OutputData[Longitude, Lattitude], @" "));
                }
                Console.WriteLine();
            }
        }
        private class WorkItem
        {
            public WorkItem(int _Longitude, int _Lattitude, int[] _RainFallSamples)
            {
                Longitude = _Longitude;
                Lattitude = _Lattitude;
                RainFallSamples = _RainFallSamples;
            }
            public int Longitude { get; set; }
            public int Lattitude { get; set; }
            public int[] RainFallSamples { get; set; }
        }
        public static int[][][] GenerateSampleRainfallData()
        {
            int[][][] Result;
            Random Rnd;
            Rnd = new Random();
            Result = new int[LongitudeSize][][];
            for(int Longitude = 0; Longitude < LongitudeSize; Longitude++)
            {
                Result[Longitude] = new int[LattitudeSize][];
                for (int Lattidude = 0; Lattidude < LattitudeSize; Lattidude++)
                {
                    Result[Longitude][Lattidude] = new int[RainFallSamplesSize];
                    for (int Sample = 0; Sample < RainFallSamplesSize; Sample++)
                    {
                        Result[Longitude][Lattidude][Sample] = Rnd.Next(SampleMinValue, SampleMaxValue);
                    }
                }
            }
            return Result;
        }
        private static object SyncRootWorkQueue = new object();
        private static Queue<WorkItem> WorkQueue = new Queue<WorkItem>();
        private static void QueueWork(WorkItem SamplesWorkItem)
        {
            lock(SyncRootWorkQueue)
            {
                WorkQueue.Enqueue(SamplesWorkItem);
            }
        }
        private static WorkItem DeQueueWork()
        {
            WorkItem Samples;
            Samples = null;
            lock (SyncRootWorkQueue)
            {
                if (WorkQueue.Count > 0)
                {
                    Samples = WorkQueue.Dequeue();
                }
            }
            return Samples;
        }
        private static int QueueSize()
        {
            lock(SyncRootWorkQueue)
            {
                return WorkQueue.Count;
            }
        }
        private static object SyncRootOutputData = new object();
        private static int[,] OutputData;
        private static void SetOutputData(int Longitude, int Lattitude, int SumSamples)
        {
            lock(SyncRootOutputData)
            {
                OutputData[Longitude, Lattitude] = SumSamples;
            }
        }
        private static void ParallelSum()
        {
            WorkItem SamplesWorkItem;
            int SummedResult;
            SamplesWorkItem = DeQueueWork();
            while (SamplesWorkItem != null)
            {
                SummedResult = 0;
                foreach (int SampleValue in SamplesWorkItem.RainFallSamples)
                {
                    SummedResult += SampleValue;
                }
                SetOutputData(SamplesWorkItem.Longitude, SamplesWorkItem.Lattitude, SummedResult);
                SamplesWorkItem = DeQueueWork();
            }
        }
    }
