    class ThreadTest
    {
        public ThreadTest() { }
    
        public void test()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Alive and kicking");
                    Thread.Sleep(2000);
                }
            }
    
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
    
            finally
            {
                Console.WriteLine("Finally");
    
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest myThreadTest = new ThreadTest();
            Thread myThread = new Thread(new ThreadStart(myThreadTest.test));
            myThread.Start();
            Thread.Sleep(5000);
            bool status = myThread.Join(1000);
            if (myThread.IsAlive)
            {
                myThread.Abort();
            }
            Thread.Sleep(5000);
        }
    }
