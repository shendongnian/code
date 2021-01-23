    foreach (Control c in myForm.Controls)
    {
      if (c is Button)
      {
        ((Button)c).Text = "---";
      }
    }
