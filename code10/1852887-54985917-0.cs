        public partial class Window2 : Window
        {
            readonly FunildeVendasDTO dto = new FunildeVendasDTO();
            readonly FunildeVendasBLL bll = new FunildeVendasBLL();
            public ObservableCollection<FunildeVendasDTO> Lista { get; private set; }
            public Window2()
            {
                InitializeComponent();
                Lista = bll.LoadNegocios();
                DataContext = this;
            }
        }
