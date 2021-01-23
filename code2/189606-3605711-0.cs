        public Form1() {
            InitializeComponent();
            if (Environment.CommandLine.ToLower() == "disble") {
                button1.Enabled = false;
                // etc..
            }
        }
