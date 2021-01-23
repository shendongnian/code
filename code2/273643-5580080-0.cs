    static class Program
    {
        public static System.Timers.Timer sendTimer;
        public static System.Text.StringBuilder accumulatedText;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sendTimer = new System.Timers.Timer();
            accumulatedText = new System.Text.StringBuilder("Started at " + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            sendTimer.Interval = 3000;
            sendTimer.Elapsed += new System.Timers.ElapsedEventHandler(sendProcessTimerEvent);
            Application.Run(new MainForm());
        }
        static void sendProcessTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            accumulatedText.AppendLine("Pinged at " + DateTime.Now.ToLongTimeString());
        }
    }
    class MainForm : Form
    {
        ToolStrip mainToolStrip = new ToolStrip();
        public MainForm()
        {
            mainToolStrip.Items.Add("Log Control").Click += new EventHandler(MainForm_Click);
            Controls.Add(mainToolStrip);
        }
        void MainForm_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
    class Form1 : Form
    {
        private Button button1 = new Button();
        private TextBox text1 = new TextBox();
        public Form1()
        {
            button1.Dock = DockStyle.Bottom;
            button1.Text = Program.sendTimer.Enabled ? "Stop": "Start";
            button1.Click += new EventHandler(button1_Click);
            text1 = new TextBox();
            text1.Dock = DockStyle.Fill;
            text1.Multiline= true;
            text1.ScrollBars = ScrollBars.Vertical;
            text1.Text = Program.accumulatedText.ToString();
            Controls.AddRange(new Control[] {button1, text1});
        }
        void button1_Click(object sender, EventArgs e)
        {
            Program.sendTimer.Enabled = !Program.sendTimer.Enabled;
            button1.Text = Program.sendTimer.Enabled ? "Stop" : "Start";
        }
    }
