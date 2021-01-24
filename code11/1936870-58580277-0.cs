    private void Button2_Click(object sender, EventArgs e)
    {
      // I assume this code will be placed inside Form class :)
      ControlTextToUpper(this);
    }
    private void ControlTextToUpper(Control control)
    {
      control.Text = control.Text.ToUpper();
      foreach (Control ctrl in control.Controls)
        ControlTextToUpper(ctrl); 
    }
