        private void txtF1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteText();
            }
        }
        private void txtF1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right &&
                ((TextBox)sender).Modified)
            {
                PasteText();
            }
        }
        private void PasteText()
        {
            string[] val = txtF1.Text.Split('.');
            txtF1.Text = val[0].ToString();
            txtF2.Text = val[1].ToString();
            txtF3.Text = val[2].ToString();
            txtF4.Text = val[3].ToString();
        }
