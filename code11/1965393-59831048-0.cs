    class MainViewModel
    {
      public MainViewModel(IFirstControlViewModel firstControlViewModel ,
        ISecondControlViewModel secondControlViewModel)
      { 
        this.FirstControlViewModel = firstControlViewModel;
        this.SecondControlViewModel = secondControlViewModel;
      }  
    
      public IFirstControlViewModel FirstControlViewModel { get; }
      public ISecondControlViewModel SecondViewModel { get; }
    }
