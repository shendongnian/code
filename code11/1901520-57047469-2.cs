    public partial class OpenDatabaseDialog : Form
    {
        public OpenDatabaseDialog()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Set any properties necessary that indicate the user's selections
            // User clicked 'Ok' so set our result (which will also close the form)
            this.DialogResult = DialogResult.OK;
        }
    }
