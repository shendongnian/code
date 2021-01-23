     private decimal _previous = 0;
    
      private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                if (((NumericUpDown)sender).Text.Length > 0)
                {
                    _previous = this.numericUpDown1.Value;
                }
            }
    
            private void UserControl1_Leave(object sender, EventArgs e)
            {
                if (this.numericUpDown1.Text == "")
                {
                    this.numericUpDown1.Value = _previous;
                    this.numericUpDown1.Text = System.Convert.ToString(_previous);
                }
            }
