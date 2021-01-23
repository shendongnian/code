    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(50, 50, 50);
            this.Opacity = 0;
            fadeTimer = new Timer { Interval = 15, Enabled = true };
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
        }
        void fadeTimer_Tick(object sender, EventArgs e) {
            this.Opacity += 0.02;
            if (this.Opacity >= 0.70) {
                fadeTimer.Enabled = false;
                // Fade done, display the overlay
                using (var overlay = new Form2()) {
                    overlay.ShowDialog(this);
                    this.Close();
                }
            }
        }
        Timer fadeTimer;
    }
