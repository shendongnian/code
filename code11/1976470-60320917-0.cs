    class MainViewModel
    {
      public CarViewModel CarViewModel { get; set; }
      public CarModifierViewModel CarModifierViewModel { get; set; }
    
      public MainViewModel()
      {
        this.CarViewModel = new CarViewModel();
        this.CarModifierViewModel = new CarModifierViewModel(this.CarViewModel);
      }
    }
