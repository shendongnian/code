    public class AllYourBase : IBase1, IBase2
    {
        // No need to explicitly implement if the value can be the same
        public double IBase1.Percentage { get { return 12d; } }
        public double IBase2.Percentage { get { return 34d; } }
    }
