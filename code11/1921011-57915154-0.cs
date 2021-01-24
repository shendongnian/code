   if (button3.Text == "Transparent")
   {
      button3.Text = "Black";
      button3.BackColor = Color.Black;
      button3.ForeColor = Color.White;
      this.BackColor = Color.LimeGreen;
      this.Opacity = 0.7;
      this.TransparencyKey = Color.LimeGreen;
   }
   else if (button3.Text == "Black")
   {
      button3.Text = "Transparent";
      button3.BackColor = Color.Black;
      button3.ForeColor = Color.White;
      this.BackColor = Color.LimeGreen;
      this.Opacity = 1.0;
      this.TransparencyKey = Color.LimeGreen;
   }
Assuming buttons initial text is already set to `Black` or `Transparent` - on click the form goes transparent, button stays visible, and it switches between the two 'states' when clicked.
