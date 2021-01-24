    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myViewModel vm = new myViewModel();
            this.BindingContext = vm;
            vm.PerformShimmerAsyncTask("123");
        }
    }
    public class myViewModel : BaseViewModel
    {
        private MyModel _attend;
        private bool _isLoadBusy = false;
        public MyModel Attend
        {
            get { return _attend; }
            set { SetProperty(ref _attend, value); }
        }
        public bool IsLoadBusy
        {
            get { return _isLoadBusy; }
            set
            {
                _isLoadBusy = value;
                OnPropertyChanged();
            }
        }
        public async Task PerformShimmerAsyncTask(string id)
        {
            this.Attend = new MyModel
            {
                AddressDetail = "x",
                Created = DateTime.Now,
                Activity = "x",
                Note = "x"
            };
            this.IsLoadBusy = true;
            await Task.Delay(10000);
            this.IsLoadBusy = false;
            this.Attend = new MyModel
            {
                AddressDetail = "asdasdasda",
                Created = DateTime.Now,
                Activity = "sadasdasdasfacf",
                Note = "asuuusfasfa"
            };
        }
    }
    public class MyModel 
    {
        public string AddressDetail { get; set; }
        public DateTime Created { get; set; }
        public string Activity { get; set; }
        public string Note { get; set; }
    }
