    using System.IO;
    ...
        private void showMyHelp() {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            path = "file://" + Path.Combine(path, "example.chm");
            Help.ShowHelp(this, path);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.F1) {
                showMyHelp();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void HelpButton_Click(object sender, EventArgs e) {
            showMyHelp();
        }
