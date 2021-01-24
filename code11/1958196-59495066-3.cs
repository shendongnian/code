      public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DItemViewModel();
        }
        private void btnItem_Clicked(object sender, EventArgs e)
        {
        }
    }
