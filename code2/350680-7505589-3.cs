    public partial class Window1 : Window
    {
       DataHandler _dataHandler;
       public Window1()
       {
            InitializeComponent();
            _dataHandler = DataHandler.Instance;
       }
    }
