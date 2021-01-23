        private void txtFirstTextBox_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtFirstTextBox.Text)) {
                txtSecondTextBox.Clear();
                return;
            }
            txtSecondTextBox.Text = txtFirstTextBox.Text;
        }
