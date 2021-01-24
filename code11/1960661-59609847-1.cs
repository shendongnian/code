    public partial class Form1 : Form
    {
        // variable to keep track if the timer is running.
        private bool _timerRunning;
        public Form1()
        {
            InitializeComponent();
        }
        private async Task StartTimer()
        {
            // set it to true
            _timerRunning = true;
            while (_timerRunning)
            {
                // call the rotateRightButton_Click (what you want)
                rotateRightButton_Click(this, EventArgs.Empty);
                pictureBox1.Refresh();
                pictureBox2.Refresh();
                // wait for 3 seconds (but don't block the GUI thread)
                await Task.Delay(3000);
            }
        }
        private void rotateRightButton_Click(Form1 form1, EventArgs empty)
        {
           // do your thing
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            // if it's already started, don't start it again.
            if (_timerRunning)
                return;
            // start it.
            await StartTimer();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            // stop it.
            _timerRunning = false;
        }
    }
