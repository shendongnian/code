    public partial class UserControlA : UserControl
    {
        public UserControlA()
        {
            InitializeComponent();
        }
        private Form1 f1;
        public Form1 F1
        {
            get { return f1; }
            set { f1 = value; }
        }
        private void foo()
        {
            if (f1 != null)
            {
                // ... do something with "f1" ...
            }
        }
    }
