        private int GetSync()
        {
            try
            {
                ManualResetEvent mre = new ManualResetEvent(false);
                int result = null;
                Parallel.Invoke(async () =>
                {
                    result = await SomeCalcAsync(5+5);
                    mre.Set();
                });
                mre.WaitOne();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
