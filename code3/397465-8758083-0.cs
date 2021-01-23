    public partial class ProgressDialog : Form {
        public ProgressDialog() {
            InitializeComponent();
        }
        public void ShowProgress(int progress) {
            progressBar1.Value = progress;
        }
        private void CancelProcess_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
