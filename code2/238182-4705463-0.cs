        private void Control_DoubleClick(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                MessageBox.Show("Ctrl is pressed!");
            }
        }
