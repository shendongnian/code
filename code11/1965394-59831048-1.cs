    class SecondViewModel : ISecondViewModel
    {
      public SecondVieModel(IThirdViewModel thirdViewModel) => this.ThirdViewModel = thirdViewModel;
    
      public IThirdViewModel ThirdViewModel { get; } 
    }
