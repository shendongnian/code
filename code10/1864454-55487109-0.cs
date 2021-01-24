    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var formB = new FormB(this.ClosingC);
            formB.Show();
        }
        private void ClosingC(FormC formC)
        {
            MessageBox.Show("Closing C");
        }
    }
