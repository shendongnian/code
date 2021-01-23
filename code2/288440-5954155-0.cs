            AutoResetEvent resetTimer = new AutoResetEvent(false);
            ...
            private void TimerJob()
            {
                ...
                // Where you do your sleep in your timer job
                while (resetTimer.WaitOne(2000))
                {
                }
                ...
            }
            private void ResetTimer()
            {
                resetTimer.Set();
            }
