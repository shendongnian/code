    class MainViewModel
    {
      public MainViewModel(IFirstControlViewModel firstControlViewModel ,
        ISecondControlViewModel secondControlViewModel,
        IThirdViewModel thirdViewModel)
      { 
        this.FirstControlViewModel = firstControlViewModel;
        this.SecondControlViewModel = secondControlViewModel;
        this.ThirdViewModel = thirdViewModel;
      }  
    
      public IFirstControlViewModel FirstControlViewModel { get; }
      public ISecondControlViewModel SecondViewModel { get; }
      public IThirdViewModel ThirdViewModel { get; } 
    }
