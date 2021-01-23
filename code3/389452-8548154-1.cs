        private void btnChangeEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strOutputEncrypt))
            {
                MessageBox.Show("Please select a file to encrypt first", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
