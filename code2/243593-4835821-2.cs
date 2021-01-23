    public class MainPageViewModel : NotifyObject
    {
        private readonly SalesOrderRepository _repository;
    
        public MainPageViewModel()
            : this(new SalesOrderRepository())
        {
        }
    
        public MainPageViewModel(SalesOrderRepository repository)
        {
            _repository = repository;
    
            this.ActiveSalesOrderNumbers = new ObservableCollection<SalesOrder>();
        }
    
        private ObservableCollection<SalesOrder> _activeSalesOrderNumbers;
        public ObservableCollection<SalesOrder> ActiveSalesOrderNumbers
        {
            get { return _activeSalesOrderNumbers; }
            set
            {
                _activeSalesOrderNumbers = value;
                NotifyPropertyChanged(() => ActiveSalesOrderNumbers);
            }
        }
    
        public void OnSalesOrderOpenedCommand()
        {
            _repository.GetSalesOrderNumbers(result =>
            {
                this.ActiveSalesOrderNumbers.Clear();
    
                result.ToList().ForEach(e => { this.ActiveSalesOrderNumbers.Add(e); });
            });
        }
    }
    
    public class SalesOrder : NotifyObject
    {
        private string _salesOrderNumber;
        public string SalesOrderNumber
        {
            get { return _salesOrderNumber; }
            set
            {
                _salesOrderNumber = value;
                NotifyPropertyChanged(() => SalesOrderNumber);
            }
        }
    
        private DateTime _lastModified;
        public DateTime LastModified
        {
            get { return _lastModified; }
            set
            {
                _lastModified = value;
                NotifyPropertyChanged(() => LastModified);
            }
        }
    }
    
    public class SalesOrderRepository
    {
        public void GetSalesOrderNumbers(Action<IEnumerable<SalesOrder>> reply)
        {
            List<SalesOrder> orders = new List<SalesOrder>();
    
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new SalesOrder { SalesOrderNumber = i.ToString(), LastModified = DateTime.Now });
            }
    
            reply(orders);
        }
    }
