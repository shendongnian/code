        private List<Panel> _panels = new List<Panel>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void OnButtonStartClick(object sender, System.EventArgs e)
        {
            _timer.Enabled = true;
            Panel newPanel = new Panel
            {
                Bounds = new Rectangle(10, 10, 50, 50),
                BorderStyle = BorderStyle.FixedSingle
            };
            _panels.Add(newPanel);
            Controls.Add(newPanel);
        }
        private void OnTimerTick(object sender, System.EventArgs e)
        {
            for (int i = _panels.Count - 1; i >= 0; i--)
            {
                Panel currentPanel = _panels[i];
                Point newLocation = new Point(currentPanel.Location.X + 25, currentPanel.Location.Y);
                // Check before or after collision (in this example before replacing the panel)
                if (newLocation.X > this.Width)
                {
                    // I chose to remove after it reaches the edge, do whatever you want
                    _panels.RemoveAt(i);
                    Controls.Remove(currentPanel);
                }
                else
                {
                    currentPanel.Location = newLocation;
                }
            }
            if (_panels.Count == 0)
            {
                _timer.Enabled = false;
            }
        }
    }
