    foreach(Control c in this.Controls)
    {
      if(c is Label && c.Text == "label-121")
      {
        c.BackColor = Color.Red;
      }
    }
