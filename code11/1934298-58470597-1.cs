    using Threading.Internal;
    
    namespace Threading
    {
        /// <summary>
        ///     Switches to a particular thread.
        /// </summary>
        public static class ThreadSwitcher
        {
            /// <summary>
            ///     Switches to the Task thread.
            /// </summary>
            /// <returns></returns>
            public static IThreadSwitcher ResumeTaskAsync()
            {
                return new ThreadSwitcherTask();
            }
    
            /// <summary>
            ///     Switch to the Unity thread.
            /// </summary>
            /// <returns></returns>
            public static IThreadSwitcher ResumeUnityAsync()
            {
                return new ThreadSwitcherUnity();
            }
        }
    }
