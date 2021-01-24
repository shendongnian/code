    public partial class MainPage : ContentPage
        {
            DemoViewModel viewModel = new DemoViewModel();
            public MainPage()
            {
                InitializeComponent();
                this.BindingContext = viewModel;
            }
        }
