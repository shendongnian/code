    public partial class ReceiveDataForm : Form
    {
        public ReceiveDataForm()
        {
            InitializeComponent();
            // Subscribe the event
            Transmitter.DataReceived += Transmitter_DataReceived;
        }
        private void Transmitter_DataReceived(object data)
        {
            // Display data.
            textBox1.Text = data.ToString();
        }
    }
