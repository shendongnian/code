    private void btn_MouseDown(object sender, MouseEventArgs e)
    {
      //Replace with the appropriate control/image/color change:
      btn.BackColor = Color.Black;
    }
    private void btn_MouseUp(object sender, MouseEventArgs e)
    {
      //As mentioned above
      btn.BackColor = SystemColors.Control;
    }
