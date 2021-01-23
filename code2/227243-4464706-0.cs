        private delegate void ChangeFocusDelegate(Control ctl);
        private void textBox1_Validating(object sender, CancelEventArgs e) {
            int value;
            if (!int.TryParse(textBox1.Text, out value)) e.Cancel = true;
            else {
                if (value == 1) this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox2);
                else this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox3);
            }
        }
        private void changeFocus(Control ctl) {
            ctl.Focus();
        }
