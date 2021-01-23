    interface IAllYourBase : IBase1, IBase2 { } 
    public class AllYourBase : IAllYourBase
    {     
          int IBase1.Percentage { get{ return 12; } }     
          int IBase2.Percentage { get{ return 34; } } 
    } 
    IAllYourBase base = new AllYourBase();    
    int percentageBase1 = (base as IBase1).Percentage;
    int percentageBase2 = (base as IBase2).Percentage;
