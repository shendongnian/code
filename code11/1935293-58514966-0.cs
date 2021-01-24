     public partial class MainPage : ContentPage
    {
        public List<string> Counter { get { return new List<string> { "1", "2" }; } }
        public List<string> Objets_de_Commande { get { return new List<string> { "test01", "test02" }; } }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
