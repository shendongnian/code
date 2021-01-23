            for (int i = 0; i < 100; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(k =>
                {
                    TestMethod(k);
                }, i);
            }
