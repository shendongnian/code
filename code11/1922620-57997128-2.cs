    public partial class Page1 : ContentPage
    {
        private ReceiptPageViewModel viewModel;
        public Page1()
        {
            BindingContext = viewModel = new ReceiptPageViewModel();
            InitializeComponent();
        }
    }
