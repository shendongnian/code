    public class UtilitiesClass
    {
        internal UtilitiesClass() { }
    
        public void UtilityMethod1()
        {
            // Do something
        }
    }
    
    // Method 1 (readonly):
    public static readonly UtilitiesClass Utilities = new UtilitiesClass();
    
    // Method 2 (property):
    private static UtilitiesClass _utilities = new UtilitiesClass();
    public static UtilitiesClass Utilities
    {
        get { return _utilities; }
        private set { _utilities = value; }
    }
