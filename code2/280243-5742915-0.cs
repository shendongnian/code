            timer.Elapsed += timer_Elapsed;
            ThreadPool.QueueUserWorkItem((obj) => DoWork());
        ...
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            DoWork();
        }
        void DoWork() {
            // etc...
        }
