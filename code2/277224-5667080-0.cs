    class Program
    {
        static void Main(string[] args)
        {
            Semaphore semaphore = new Semaphore(0, 1, "SharedSemaphore");
            var domain = AppDomain.CreateDomain("Test");
            
            Action callOtherDomain = () =>
                {
                    domain.DoCallBack(Callback);
                };
            callOtherDomain.BeginInvoke(null, null);
            semaphore.WaitOne();
            // Once here, you should evaluate whether to exit the application, 
            //  or perform the task again (create new domain again?....)
        }
        static void Callback()
        {
            var sem = Semaphore.OpenExisting("SharedSemaphore");
            Thread.Sleep(10000);
            sem.Release();
        }
    }
