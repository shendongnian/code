     public class Class1
    {
        IThreadSleep _threadSleep;
        public Class1(IThreadSleep threadSleep)
        {
            _threadSleep = threadSleep;
        }
        public void SomeMethod()
        {
            // 
            _threadSleep.Sleep(100);
        }
    }
