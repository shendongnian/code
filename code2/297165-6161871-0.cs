    static void Main(string[] args)
    {
        Semaphore S = new Semaphore(5, 5);
        One O = new One(S);
        for (int j = 0; j < 10; j++)
        {
            Thread T = new Thread(new ParameterizedThreadStart(O.Run));
            T.Start(j);
        }
    }
    
    public class One
    {
        Semaphore S = null;
        public One(Semaphore S)
        {
            this.S = S;
        }
        public void Run(object ID)
        {
            S.WaitOne();
            Console.WriteLine("Thread [" + ID + "] Entered");
            Random R = new Random();
            Thread.Sleep(R.Next(100, 1000));
            Console.WriteLine("Thread [" + ID + "] Exited");
            S.Release();
        }
    }
