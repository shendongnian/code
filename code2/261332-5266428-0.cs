    class Poller
    {
        // other stuff here
    
        System.Threading.Timer PollTimer = null;
    
        public void StartPolling(int pollFrequency)
        {
            PollTimer = new System.Threading.Timer((s) => { Poll(); }, null, pollFrequency, pollFrequency);
        }
    
        public void StopPolling()
        {
            PollTimer.Dispose();
        }
    }
