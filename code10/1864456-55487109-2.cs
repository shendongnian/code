    public partial class FormC : Form
    {
        public FormC()
        {
            InitializeComponent();
        }
        private Action<FormC> _closingFormC = null;
        public FormC(Action<FormC> closingFormC)
            : this()
        {
            _closingFormC = closingFormC;
        }
        private void FormC_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closingFormC?.Invoke(this);
        }
    }
