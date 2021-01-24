        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Ignore)
            {
                e.Cancel = false;
                return;
            }
            DialogResult result = MessageBox.Show("Sure?", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }
