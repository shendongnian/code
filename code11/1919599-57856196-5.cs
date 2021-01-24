    public class FirstViewModel : ViewModelbase
    {
      public FirstViewModel() 
      {
        // Create a collection with mixed types all derived from ViewModellBase
        this.ChildItems = new ObservableCollection<ViewModeLBase>() 
        { 
          new SecondViewModel(), 
          new ThirdViewModel(),
          new IndUsecaseViewModel()
        };
      }
      public ObservableCollection<ViewModelBase> ChildItems { get;set; }    
    }
