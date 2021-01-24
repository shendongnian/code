    class Abc
    {
      private MainViewModel mainViewModel; 
    
      public Abc()
      {
        this.mainViewModel = Application.Current.Resources["SharedMainViewModel"] as MainViewModel;
      }
    }
