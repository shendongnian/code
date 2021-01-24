    public class MainViewModel : INotifyPropertyChanged
    {
      public FirstViewModel FirstViewModel { get; private set; }
      public SecondViewModel SecondViewModel { get; private set; }
    
      public MainViewModel()
      {
        this.FirstViewModel = new FirstViewModel();
        this.SecondViewModel = new SecondViewModel();
      }
    }
    
    public class FirstViewModel : INotifyPropertyChanged
    {
      public MyICommand<string> FirstCommand { get; private set; }
    
      public FirstViewModel()
      {
        FirstCommand = new MyICommand<string>(myFirstCommand);
      }
    
      public void myFirstCommand(string par)
      {
        Console.Beep();
      }
    }
    
    
    public class SecondViewModel : INotifyPropertyChanged
    {
      public MyICommand<string> SecondCommand { get; private set; }
    
      public SecondViewModel()
      {
        SecondCommand = new MyICommand<string>(mySecondCommand);
      }
    
      public void mySecondCommand(string par)
      {
        Console.Beep();
      }
    }
