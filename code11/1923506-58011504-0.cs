    private void button1_Click(object sender, EventArgs e)
    {
      this.bg.FullOpen = true;
      if ( this.bg.ShowDialog() == DialogResult.OK )
      {
        setBgColor(Controls, bg.Color);
      }
    }
    public void setBgColor(Control.ControlCollection controls, Color rgb)
    {
      foreach ( Control control in controls )
      {
        if ( control is Panel )
          ( (Panel)control ).BackColor = rgb;
        setBgColor(control.Controls, rgb);
      }
    }
