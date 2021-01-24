    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (_cancellation == null)
                return;
            if (e.KeyCode == Keys.A)
                _cancellation.Cancel();
        }
        async void button1_Click(object sender, EventArgs e)
        {
            if (_cancellation != null) // Already waiting?
                return;
            button1.Enabled = false;
            button1.Text = "Waiting...";
            _cancellation = new CancellationTokenSource();
            UsbButtonWaiter waiter = new UsbButtonWaiter(_cancellation.Token);
            bool wasUsbButtonPressed = await waiter.WaitForUsbButtonAsync();
            if (wasUsbButtonPressed)
                MessageBox.Show("USB button was pressed");
            else
                MessageBox.Show("Cancel key was pressed");
            button1.Enabled = true;
            button1.Text = "button1";
        }
        CancellationTokenSource _cancellation;
    }
