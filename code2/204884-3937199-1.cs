       for (int i = 0; i < _workers.Length; ++i)
        {
            int j = i;  // copy
            Task t1 = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (!_workers[j].Join(4000))  // j
                        LogWriter.Trace("Failed to join thread", "ThreadFailureOnDispose");
                }
