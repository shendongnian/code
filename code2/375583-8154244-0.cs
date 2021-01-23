    class A
    {
        AutoResetEvent are = new AutoResetEvent(false);
        public void Download()
        {
            are.Reset();
            try
            {
                //Do your work here
            }
            finally
            {
                are.Set();
            }
        }
        public void Query()
        {
            are.WaitOne();
        }
    }
