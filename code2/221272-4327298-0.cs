    public class Vehicle
    {
        private bool isEngineStarted;
        private void StartEngine()
        {
            // Code here.
            this.isEngineStarted = true;
        }
        public void GoToLocation(Location location)
        {
            if (!this.isEngineStarted)
            {
                this.StartEngine();
            }
            // Code here: move to a new location.
        }
    }
