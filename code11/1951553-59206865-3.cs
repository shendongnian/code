      class LongRunningLogic
    {
        public void LongRunningTask(CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested )
            {
                //Long running code 
            }
        }
    }
