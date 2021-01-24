    public partial class FormB : Form
    {
        public FormB()
        {
            InitializeComponent();
        }
        private Action<FormC> _closingFormC = null;
        public FormB(Action<FormC> closingFormC)
            : this()
        {
            _closingFormC = closingFormC;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var formC = new FormC(_closingFormC);
            formC.Show();
        }
    }
