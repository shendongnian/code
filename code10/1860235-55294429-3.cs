    public sealed class Locator
        {
        private static Locator locator = null;
        private static readonly object padlock = new object();
    
        Locator()
        {
          //your registries
        }
    
        public static Locator Locator
        {
        get
        {
        lock (padlock)
        {
        if (locator == null)
        {
        locator = new Locator();
        }
        return locator;
        }
        }
        }
        }
