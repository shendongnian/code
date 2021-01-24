    public partial class Mapping: Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public ViewModel ()
        {
            InitializeComponent();
            DataContext = viewModel ;
        }
    }
    
  
