    public partial class OpenDatabaseDialog : Form
    {
        public OpenDatabaseDialog()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            // User clicked 'Ok' so set our result
            this.DialogResult = DialogResult.OK;
            // Set other properties here as well that indicate what the user chose
            // Close this dialog form
            this.Close();
        }
    }
