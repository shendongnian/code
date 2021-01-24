    public class Timer 
    {
        private float _startTime;
        public bool IsRunning;
    
        // you don't need an extra reset method
        // simply pass it as a parameter
        public void Start(bool reset = false)
        {
            if(IsRunning && !reset)
            {
                Debug.LogWarning("Timer is already running! If you wanted to restart consider passing true as parameter.");
                return;
            }
    
            _startTime = Time.time;                                             
    
            Debug.Log("in Start: " + GetFormattedTime(_startTime));
    
            IsRunning = true;
        }
    
        // depending what stop should do
        // since this doesn't use any resources while running you could also simply
        // only stick to the Start method and pass in true .. does basically the same
        public void Stop()
        {
            IsRunning = false;
        }
    
        // I didn't see any difference between you two methods so I would simply use
        public string GetCurrentTime()
        {
            if(!IsRunning)
            {
                Debug.LogWarning("Trying to get a time from a Timer that isn't running!");
                return "--:--:---";
            }
    
            var timeDifference = Time.time - _startTime;
            
            return GetFormattedTime(timeDifference);
        }
        private static string GetFormattedTime(float time)
        {
                                                                      // e.g. time = 74.6753
            var minutes = Mathf.FloorToInt(time / 60f);               // e.g. 1 (rounded down)
            var seconds = Mathf.FloorToInt(time - 60f * minutes);      // e.g.  14 (rounded down)
            var fraction = Mathf.RoundToInt((time - seconds) * 1000f); // e.g. 676 (rounded down or up)
    
            // Use a string interpolation for better readability
            return $"{minutes:00}:{seconds:00}:{fraction:000}";
        }
    }
    
