        bool showClosingEventMessage = true;
        private void button1_Click(object sender, EventArgs e)
        {
            showClosingEventMessage = false;
            this.Hide();
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            showClosingEventMessage = true;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (showClosingEventMessage)
            {
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
        }
