    public class CarModifierViewModel
    {
      private CarViewModel CarViewModel { get; set; }
    
      public CarModifierViewModel(CarViewModel carViewModel)
      {
        this.CarViewModel = carViewModel;
      }
    
      public void LoadCarAndModel()
      {
        // Now 'CarViewModel' won't be null, 
        // as long as you don't pass null to the constructor
        // or set the 'MainViewModel.CarViewModel' property to null
        PreviouslySelectedCar = this.CarViewModel.SelectedCar.Name;
        PreviouslySelectedModel = this.CarViewModel.SelectedModel.Name;
      }
    }
