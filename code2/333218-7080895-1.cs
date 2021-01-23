    public class AllYourBase : IBase1, IBase2
    {
        int IBase1.Percentage { get{ return 12; } }
        int IBase2.Percentage { get{ return 34; } }
    }
