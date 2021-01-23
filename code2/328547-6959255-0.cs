    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        Timer timer1;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            timer1 = new Timer();
            timer1.Interval = 3000;
            timer1.Start();
            var t = new System.Threading.Thread(stopTimer);
            t.Start();
        }
        private void stopTimer() {
            timer1.Enabled = false;
            System.Diagnostics.Debug.WriteLine(timer1.Enabled.ToString());
        }
    }
