    public partial class Window1 : Window
    {
        private object _whatINeedToReference;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(object whatINeedToReference):this()
        {
            _whatINeedToReference = whatINeedToReference;
        }
    }
