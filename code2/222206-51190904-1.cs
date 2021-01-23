    public class MainForm
    {
        //...
    
        public Form form = null;
    
        public MainForm(MyControl myControl)
        {
            InitializeComponent();
            //...
            myControl.form = (Form)this;
        }
    }
