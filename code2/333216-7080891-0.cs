    interface AllYourBase : IBase1, IBase2
    {
       int IBase1.Percentage { get; set; }
       int IBase2.Percentage { get; set; }
    }
