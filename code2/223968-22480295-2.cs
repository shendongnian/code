    public partial class WaitingDialog : Form
    {
        public WaitingDialog()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            // Other stuff
        }
        protected override void OnPaintBackground(PaintEventArgs e) { /* Ignore */ }
    }
