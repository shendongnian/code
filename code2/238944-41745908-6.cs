    public class HostingEnvironmentRegisteredObject : IRegisteredObject
    {
        // this is called both when shutting down starts and when it ends
        public void Stop(bool immediate)
        {
            if (immediate)
                return;
            // shutting down code here
            // there will about Shutting down time limit seconds to do the work
        }
    }
