    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2(this);
            f.Show();
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }        
    }
    public partial class Form2 : Form
    {
        private Form1 _parentForm;
        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _parentForm.ShowMessage("I am a message from form1);
        }   
    }
    
