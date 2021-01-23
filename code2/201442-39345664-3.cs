    public class MyForm : Form
    {
        private static MyForm alreadyOpened = null;
        
        public MyForm()
        {
            InitializeComponent();
            if (alreadyOpened != null)
                alreadyOpened.Close();
            alreadyOpened = this;
        }
    }
