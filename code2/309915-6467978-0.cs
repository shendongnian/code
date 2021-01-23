    public class OrdersViewModel:INotifyPropertyChanged
    {
      //Probably want to initialize this in a constructor to populate the collection
      private ObservableCollection<Order> _orders= new ObservableCollection<Order>();
      private ICommand _addOrder;
      
      public OrdersViewModel()
      {
        _addOrderCommand = new DelegateCommand(execute:(obj)=>AddOrder());
        //or use the relay command depending on which framework you're using
      }
      public ICommand AddOrderCommand{get {return _addOrder}};
      public ObservableCollection<Order> Orders
      {
        get{return _orders;}
        //I usually don't add a public setter for ObservableCollections
      }
      
      public void AddOrder()
      {
        //replace with your own logic of course
        _orders.Add(new Order());
      }
    }
