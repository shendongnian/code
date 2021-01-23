    public partial class WaitingDialog : Form
    {
        public WaitingDialog()
        {
            InitializeComponent();
    
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = Color.Transparent; // I had to add this to get it to work.
    
            // Other stuff
        }
    
        protected override void OnPaintBackground(PaintEventArgs e) { /* Ignore */ }
    }
