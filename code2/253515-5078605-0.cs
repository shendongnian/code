    TextBox t;
    
    private void radio_CheckedChanged(object sender, System.EventArgs e)
    {
    	if (radio.Checked) {
              t = new TextBox();
              t.Top = radio.Top;
              t.Left = radio.Left + radio.Width;
              this.Controls.Add(t);
              t.Show();
            } else {
              t.Dispose();
            }		
    }
