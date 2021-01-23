    public partial class FormA : Form
    {
        private FormB formB;
        public FormA()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (formB == null || formB.IsDisposed)
            {
                formB = new FormB();
            }
            formB.UpdateLabel("Button A");
            formB.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (formB == null || formB.IsDisposed)
            {
                formB = new FormB();
            }
            formB.UpdateLabel("Button B");
            formB.Show();
        }
    }
    public partial class FormB : Form
    {
        public FormB()
        {
            InitializeComponent();
        }
        public void UpdateLabel(string message)
        {
            label1.Text = message;
        }
    }
