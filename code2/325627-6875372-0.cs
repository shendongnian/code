    public partial class YourForm
    {
        private Control _LastFocusedControl;
        public YourForm()
        {
            InitializeComponent();
            var controlsToWatchForFocusChange = ...;   // Some IEnumerable<Control>, e.g. `new[] { txtTextBox1, txtTextBox2 }`
            foreach (var control in controlsToWatchForFocusChange) {
                control.GotFocus += OnControlFocused;
            }
        }
        private void OnControlFocused(object sender, EventArgs e)
        {
            _LastFocusedControl= (Control)sender;
        }
    }
