    public partial class Main_Menu3 : Form
    {
        bool Active;
        //Color setcolor = new Color();
        Color StartColor = Color.FromArgb(91, 65, 193);
        Color EndColor = Color.FromArgb(242, 90, 95);
        int Steps = 30;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Main_Menu3()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint | 
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            InitializeComponent();
        }
        public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
        {
            int stepA = ((end.A - start.A) / (steps - 1));
            int stepR = ((end.R - start.R) / (steps - 1));
            int stepG = ((end.G - start.G) / (steps - 1));
            int stepB = ((end.B - start.B) / (steps - 1));
            for (int i = 0; i < steps; i++) {
                yield return Color.FromArgb(start.A + (stepA * i),
                                            start.R + (stepR * i),
                                            start.G + (stepG * i),
                                            start.B + (stepB * i));
            }
        }
        private async Task SetGradients()
        {
            IEnumerable<Color> colors = GetGradients(StartColor, EndColor, Steps);
            while (true) {
                foreach (var color in colors) {
                    if (color == colors.Last()) {
                        colors = colors.Reverse();
                        break;
                    }
                    await Task.Delay(1);
                    this.BeginInvoke(new MethodInvoker(() => { label6.ForeColor = color; }));
                }
            }
        }
        private void CustomButton1_MouseEnter(object sender, EventArgs e)
        {
            customButton1.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void CustomButton1_MouseLeave(object sender, EventArgs e)
        {
            customButton1.ForeColor = Color.FromArgb(100, 100, 100);
        }
        private void Main_Menu3_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C://RC-M_Theme")) {
                Directory.CreateDirectory("C://RC-M_Theme");
            }
            if (File.Exists("C://RC-M_Theme/backgroundimage.png")) {
                this.BackgroundImage = new Bitmap("C:/RC-M_Theme/backgroundimage.png");
            }
        }
        private void Main_Menu3_Shown(object sender, EventArgs e) 
            => Task.Run(async ()=> await SetGradients());
        private async void Main_Menu3_Activated(object sender, EventArgs e)
        {
            this.Active = true;
            base.Opacity = 0.75;
            for (int i = 1; i <= 25; i++) {
                bool active = this.Active;
                if (active) {
                    base.Opacity += 0.01;
                    await Task.Delay(1);
                }
            }
        }
        private async void Main_Menu3_Deactivate(object sender, EventArgs e)
        {
            try {
                this.Active = false;
                base.Opacity = 0.75;
                for (int i = 1; i <= 25; i++) {
                    bool flag = !this.Active;
                    if (flag) {
                        base.Opacity -= 0.01;
                        await Task.Delay(1);
                    }
                }
            }
            catch { }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Main_Menu3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            await ShowPanel(panel7, 50);
        }
        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            await HidePanel(panel7, 50);
        }
        int scrollStep = 20;
        bool isPanelShowing = false;
        private async Task ShowPanel(Panel panel, int delay)
        {
            if (isPanelShowing) return;
            isPanelShowing = true;
            while (panel.Left < 0) {
                panel.Left += scrollStep;
                await Task.Delay(delay);
            }
            isPanelShowing = false;
        }
        private async Task HidePanel(Panel panel, int delay)
        {
            if (isPanelShowing) return;
            isPanelShowing = true;
            while (panel.Left > -panel.Width) {
                panel.Left -= scrollStep;
                await Task.Delay(delay);
            }
            isPanelShowing = false;
        }
        private async void FadeIn(Control ctrl, int interval = 80)
        {
            ctrl.BackColor = Color.FromArgb(0, 39, 42, 52);
            while (ctrl.BackColor.A < 245) {
                await Task.Delay(interval);
                ctrl.BackColor = Color.FromArgb(ctrl.BackColor.A + 10, 39, 42, 52);
            }
            ctrl.BackColor = Color.FromArgb(255, 39, 42, 52);
        }
        private async void FadeOut(Form form, int interval = 80)
        {
            Color c = form.BackColor;
            //Object is fully visible. Fade it out
            while (form.Opacity > 0.1f) {
                await Task.Delay(interval);
                form.Opacity -= 0.05f;
            }
            form.Opacity = 0.1f; //make fully invisible       
        }
    }
