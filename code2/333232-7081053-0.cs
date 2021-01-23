    interface IAllYourBase : IBase1, IBase2
    {
    	new int Percentage { get; set; }
    }
    
    class AllYourBase : IAllYourBase
    {
       int percentage;
    
       public int Percentage {
          get { return percentage; }
          set { percentage = value; }
    	}
    
        int IBase1.Percentage {
          get { return percentage; }
          set { percentage = value; }
    	}
    
    	int IBase2.Percentage {
          get { return percentage; }
          set { percentage = value; }
       }
    }
