       public partial class MainPage : ContentPage
    {
        ViewModelBase viewModelBase;
        public MainPage()
        {
            InitializeComponent();
            viewModelBase =  new ViewModelBase();
            BindingContext = viewModelBase;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            viewModelBase.nbr_objet = 111;
        }
    }
