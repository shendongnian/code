    public class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            // Event registration doesn't have to be here, but it will work 
            // This assumes your usercontrol is hosted on the form and is named
            // "myControl"
            myControl.KeyDown += new EventHandler<KeyEventArgs>(MyControl_KeyDown);
        } 
        public void MyControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Do something. 
            // This event will fire whenever the user presses 
            // a key on the child user control
        }
    }
