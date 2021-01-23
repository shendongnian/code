    private const string OneInstanceMutexName = @"Global\MyUniqueName";
    private static void Main()
    {
        Thread.Sleep(5000);
        bool firstInstance = false;
        using (System.Threading.Mutex _oneInstanceMutex = new System.Threading.Mutex(true, OneInstanceMutexName, out firstInstance))
        {
            if (firstInstance)
            {
                //....
            }
         }
    }
