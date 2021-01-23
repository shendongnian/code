         public delegate void TimerEventHandler(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2);
        /// <summary>
        /// A multi media timer with millisecond precision
        /// </summary>
        /// <param name="msDelay">One event every msDelay milliseconds</param>
        /// <param name="msResolution">Timer precision indication (lower value is more precise but resource unfriendly)</param>
        /// <param name="handler">delegate to start</param>
        /// <param name="userCtx">callBack data </param>
        /// <param name="eventType">one event or multiple events</param>
        /// <remarks>Dont forget to call timeKillEvent!</remarks>
        /// <returns>0 on failure or any other value as a timer id to use for timeKillEvent</returns>
        [DllImport("winmm.dll", SetLastError = true,EntryPoint="timeSetEvent")]
        static extern UInt32 timeSetEvent(UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler, ref UInt32 userCtx, UInt32 eventType);
        /// <summary>
        /// The multi media timer stop function
        /// </summary>
        /// <param name="uTimerID">timer id from timeSetEvent</param>
        /// <remarks>This function stops the timer</remarks>
        [DllImport("winmm.dll", SetLastError = true)]
        static extern void timeKillEvent(  UInt32 uTimerID );
