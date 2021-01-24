    public class MainPage : ...
    {
       public MyViewModel MyViewModel { get; set; } = new MyViewModel();
       public MainPage()
       {         
          this.DataContext = this;
       }
    }
    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set;} = new ObservableCollection<Customer>();
    }
