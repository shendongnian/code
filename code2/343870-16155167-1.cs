        public static class ConnectionManager {
            private static bool initialized = false;
            private static DateTime lastStartedAt = DateTime.Now;
            private static Timer timer = null;
            private static void Initialize() {
                if (timer == null) {
                    timer = new Timer() {
                        AutoReset = true,
                    };
                    timer.Elapsed += new ElapsedEventHandler(GetPulses);
                }
            }
            public static void Start(int interval) {
                lastStartedAt = DateTime.Now;
                Initialize(); // Create a timer if necessary.
                timer.Enabled = true;
                timer.Interval = interval;
            }
            public static void Stop() {
                timer.Enabled = false;
            }
        }
