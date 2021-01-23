    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.TopMost = true;
        }
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x08000000; // Turn on WS_EX_NOACTIVATE;
                return cp;
            }
        }
    }
