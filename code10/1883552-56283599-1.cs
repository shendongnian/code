            var trylater = true;
            while (trylater)
            {
                lock (s)
                {
                    if (s.CurrentCount >= batchsize)
                    {
                        for (int i = 0; i < batchsize; i++)
                        {
                            s.Wait();
                        }
                        trylater = false;
                    }
                }
                if (trylater)
                {
                    Thread.Sleep(20);
                }
            }
