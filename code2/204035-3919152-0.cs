    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void txtTestPrime_Click(object sender, EventArgs e)
        {
            // this instantiate a new class, which now is not needed
            //TestPrime myNumber = new TestPrime();
            lblAnswer.Text = TestPrime(ToInt16(txtTestPrime.Text)) ? "it is prime!" : "it is NOT prime!";
        }
        public bool TestPrime(short number)
        {
            /* your logic */
            /* this method expects a boolean as the return type */
        }
    }
