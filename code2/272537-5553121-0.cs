    public partial class Page1 : Page,  ICanClose
    {
        public Page1()
        {
            InitializeComponent();
        }
        public bool CanClose()
        {
            return false;
        }
    }
