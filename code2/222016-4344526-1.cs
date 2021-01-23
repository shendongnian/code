    public class SlowCountProvider
    {
        public int Count
        {
            get
            {
                Thread.Sleep(1000);
                return 10;
            }
        }
    }
    public class KeyValuesWithSlowCountProvider
    {
        public SlowCountProvider KeyValues
        {
            get { return new SlowCountProvider(); }
        }
    }
