        /// <summary>
        /// Usage: var tmr = SetInterval(DoThis, 1000);
        /// Updating the UI: BeginInvoke((Action)(() =>{ //Code Here; }));
        /// </summary>
        /// <returns>Returns a timer object which can be disposed.</returns>
        public static System.Threading.Timer SetIntervalThread(Action Act, int Interval)
        {
            TimerStateManager state = new TimerStateManager();
            System.Threading.Timer tmr = new System.Threading.Timer(new TimerCallback(_ => Act()), state, Interval, Interval);
            state.TimerObject = tmr;
            return tmr;
        }
