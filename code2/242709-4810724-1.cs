        System.Timers.Timer timer = new System.Timers.Timer();
        object locker = new object();
        ManualResetEvent timerDead = new ManualResetEvent(false);
        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            lock (locker) {
                if (timerDead.WaitOne(0)) return;
                // etc...
            }
        }
        private void StopTimer() {
            lock (locker) {
                timerDead.Set();
                timer.Stop();
            }
        }
