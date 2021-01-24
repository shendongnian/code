    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PurchasePriceModel model = new PurchasePriceModel();
            BindingContext = model;
        }
    }
    class PurchasePriceModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double PurchasePriceStepperValue
        {
            get => Preferences.Get(nameof(PurchasePriceStepperValue), 1.75);
            set
            {
                Preferences.Set(nameof(PurchasePriceStepperValue), value);
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PurchasePriceStepperValue)));
            }
        }
        public PurchasePriceModel()
        {
           
        }
        
    }
