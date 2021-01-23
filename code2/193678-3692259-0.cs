        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            bool ok = e.KeyChar == 8;  // Backspace
            if ("0123456789ABCDEF".Contains(char.ToUpper(e.KeyChar))) ok = true;
            if (!ok) e.Handled = true;
        }
        private void textBox1_Validating(object sender, CancelEventArgs e) {
            int value;
            if (textBox1.Text.Length > 0) {
                if (!int.TryParse(this.textBox1.Text, System.Globalization.NumberStyles.HexNumber, null, out value)) {
                    this.textBox1.SelectAll();
                    e.Cancel = true;
                }
                else {
                    textBox1.Text = value.ToString("X8");
                }
            }
        }
