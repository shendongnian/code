        private void CustomFormControl_DoubleClick(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                MessageBox.Show("Ctrl is pressed!");
            }
        }
