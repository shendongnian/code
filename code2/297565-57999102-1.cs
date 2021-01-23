        /// <summary>
        /// Usage: var tmr = SetInterval(DoThis, 1000);
        /// Updating the UI: BeginInvoke((Action)(() =>{ //Code Here; }));
        /// </summary>
        /// <returns>Returns a timer object which can be stopped and disposed.</returns>
        public static System.Timers.Timer SetInterval(Action Act, int Interval)
        {
            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Elapsed += (sender, args) => Act();
            tmr.AutoReset = true;
            tmr.Interval = Interval;
            tmr.Start();
    
            return tmr;
        }
