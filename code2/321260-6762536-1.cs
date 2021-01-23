        System.Threading.Semaphore s1 = new System.Threading.Semaphore(2, 2);
        public void BeginSomething()
        {
            // This decrements the value of s1.
            s1.WaitOne();
        }
        public void EndSomething()
        {
            // This increments the value of s1.
            s1.Release();
        }
        public void BlockedMethod()
        {
            bool execute = true;
            // Try to get access.
            for (int i = 0; i < 2; i++)
            {
                if (!s1.WaitOne(0))
                {
                    for (; i >= 0; i--)
                    {
                        s1.Release();
                    }
                    execute = false;
                    break;
                }
            }
            if (execute)
            {
                // This code is only executed if s1 has its starting value 2.
                for (int i = 0; i < 2; i++)
                {
                    s1.Release();
                }
            }
        }
