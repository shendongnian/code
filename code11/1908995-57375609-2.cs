    public partial class MainForm : Form
    {
        // X directional speed in pixels per second
        const int XSpeed = 400;
        private List<AnimationPanel> _panels = new List<AnimationPanel>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void OnButtonStartClick(object sender, System.EventArgs e)
        {
            AnimationPanel newPanel = new AnimationPanel
            {
                Bounds = new Rectangle(10, 10, 50, 50),
                BorderStyle = BorderStyle.FixedSingle,
            };
            _panels.Add(newPanel);
            Controls.Add(newPanel);
            newPanel.StartBounds = newPanel.Bounds;
            newPanel.StartTime = DateTime.Now;
            _timer.Enabled = true;
        }
        private void OnTimerTick(object sender, System.EventArgs e)
        {
            for (int i = _panels.Count - 1; i >= 0; i--)
            {
                AnimationPanel currentPanel = _panels[i];
                DateTime startTime = currentPanel.StartTime;
                int xDelta = (int)Math.Round((DateTime.Now - startTime).TotalSeconds * XSpeed, 0);
                Point newLocation = new Point(currentPanel.StartBounds.X + xDelta, currentPanel.StartBounds.Y);
                // Check before or after collision (in this example before replacing the AnimationPanel)
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
        private class AnimationPanel : Panel
        {
            public Rectangle StartBounds { get; set; }
            public DateTime StartTime { get; set; }
        }
    }
