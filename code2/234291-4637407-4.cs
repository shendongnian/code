    public class MyForm : Form 
    {
        // form initialization, etc, etc.
        private Button button1;
        private Button button2;
        public MyForm()
        {
            InitializeComponent();
            button1.Click += HandleButtonClicked;
            button1.DialogResult = DialogResult.OK;
            button2.Click += HandleButtonClicked;
            button2.DialogResult = DialogResult.OK;
        }
        private void HandleButtonClicked(object sender, EventArgs e)
        {
            ButtonClicked = sender as Button;
        }
    
        public Button ButtonClicked
        {
            get; private set;
        }
    }
