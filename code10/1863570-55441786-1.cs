    public partial class MainConsole : Form
    {
        // Note that we are NOT creating an instance of MainGame anywhere in this Form!
        private MainGame m = null; // initially null; will be set in Constructor
        public MainConsole()
        {
            InitializeComponent();
        }
        public MainConsole(MainGame main)
        {
            InitializeComponent();
            this.m = main; // store the reference passed in for later use
        }
        private void ConsoleInput2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && ConsoleInput2.Text.Trim().Length > 0)
            {
                // Use the instance of MainGame, "m", that was passed in:
                Text_IP_Connected.Text = m.checkCommands(ConsoleInput2.Text);
                vic_sft.Enabled = (m.Is_Connected == 1);
            }
        }
    }
