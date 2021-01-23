    using MessageBox = System.Windows.Forms.MessageBox;
    using MessageBoxImage = System.Windows.Forms.MessageBoxIcon;
    using MessageBoxButton = System.Windows.Forms.MessageBoxButtons;
    using MessageBoxResult = System.Windows.Forms.DialogResult;
    namespace ... class ...
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.Application.EnableVisualStyles();
        }
        public void do()
        {
            // updated style, but good syntax for a later solution
            MessageBox.Show("Some Message", "DEBUG", MessageBoxButton.OK, MessageBoxImage.Question);
        }
