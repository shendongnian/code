        private void btnChangeDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strOutputDecrypt))
            {
                MessageBox.Show("Please select a file to decrypt first", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
