    public partial class SendDataForm : Form
    {
        public SendDataForm()
        {
            InitializeComponent();
        }
        private void SendDataButton_Click(object sender, EventArgs e)
        {
            Transmitter.TransmitData(dataTextBox.Text);
        }
    }
