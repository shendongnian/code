    interface IAllYourBase : IBase1, IBase2
    {
        int B1Percentage{ get; }
        int B2Percentage{ get; }
    }
    class AllYourBase : IAllYourBase 
    {
       public int B1Percentage{ get{ return 12; } }
       public int B2Percentage{ get{ return 34; } }
       IBase1.Percentage { get { return B1Percentage; } }
       IBase2.Percentage { get { return B2Percentage; } }
    }
