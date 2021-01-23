        System.Threading.Semaphore s1 = new System.Threading.Semaphore(2, 2);
        public void MethodA()
        {
            s1.WaitOne();
        } 
        public void MethodB()
        {
            s1.Release();
        }
        public void BlockedMethod()
        {
            s1.WaitOne();
            s1.WaitOne();
        }
